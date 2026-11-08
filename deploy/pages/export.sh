#!/usr/bin/env bash
# Saves the running website as static files for GitHub Pages.
# Usage: export.sh <running-site-url> <public-site-url> <output-directory>
set -euo pipefail

SOURCE_URL="${1%/}"
PUBLIC_URL="${2%/}"
OUTPUT_DIR="$3"
PUBLIC_HOST="${PUBLIC_URL#*://}"
ASSET_PATTERN='\.(css|js|svg|png|jpg|jpeg|webp|ico|woff2?|ttf)$'

mkdir -p "$OUTPUT_DIR"
cd "$OUTPUT_DIR"

fetch_page() {
    curl --silent --show-error --fail --output "$2" "$SOURCE_URL$1"
}

fetch_page / index.html
fetch_page /words2widget words2widget.html
fetch_page /impressum impressum.html
fetch_page /datenschutz datenschutz.html
fetch_page /not-found 404.html

fetch_asset() {
    local path="$1"
    [[ -f "$path" ]] && return 0
    mkdir -p "$(dirname "$path")"
    curl --silent --show-error --fail --output "$path" "$SOURCE_URL/$path"
}

page_assets() {
    grep --only-matching --no-filename --extended-regexp '(href|src)="[^"#:]+"' ./*.html \
        | sed --regexp-extended 's/^(href|src)="\/?//; s/"$//'
    grep --only-matching --no-filename --extended-regexp "$SOURCE_URL/[^\" ]+" ./*.html \
        | sed "s#^$SOURCE_URL/##"
}

while read -r asset; do
    fetch_asset "$asset"
done < <(page_assets | grep --extended-regexp "$ASSET_PATTERN" | sort --unique)

# Stylesheets reference fonts relative to their own location.
while read -r stylesheet; do
    directory="$(dirname "$stylesheet")"
    while read -r reference; do
        reference="${reference%%[?#]*}"
        [[ -z "$reference" ]] && continue
        fetch_asset "$(realpath --canonicalize-missing --relative-to=. "$directory/$reference")"
    done < <(grep --only-matching --extended-regexp 'url\([^)]+\)' "$stylesheet" \
        | sed --regexp-extended "s/^url\(['\"]?//; s/['\"]?\)$//" \
        | grep --invert-match --extended-regexp '^(data:|https?:|#)' \
        | sort --unique || true)
done < <(find . -name '*.css' -printf '%P\n')

sed --in-place "s#$SOURCE_URL#$PUBLIC_URL#g" ./*.html

touch .nojekyll
printf '%s\n' "$PUBLIC_HOST" > CNAME
