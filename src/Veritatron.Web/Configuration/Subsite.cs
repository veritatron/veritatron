using System.ComponentModel.DataAnnotations;

namespace Veritatron.Web.Configuration
{
    /// <summary>
    /// A website or application Veritatron links to.
    /// </summary>
    public class Subsite : IValidatableObject
    {
        private const char PathSeparator = '/';
        private const string ProtocolRelativePrefix = "//";

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a short description of one or two sentences.
        /// </summary>
        [Required]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets whether the subsite is online or announced as a preview.
        /// </summary>
        public SubsiteStatus Status { get; set; } = SubsiteStatus.Live;

        /// <summary>
        /// Gets or sets the absolute HTTP or HTTPS address of an external site.
        /// </summary>
        public Uri? Url { get; set; }

        /// <summary>
        /// Gets or sets the root-relative path of a page on this website, used instead of <see cref="Url"/>.
        /// </summary>
        public string? Path { get; set; }

        /// <summary>
        /// Gets whether the subsite is online and can be linked.
        /// </summary>
        public bool IsLive => Status == SubsiteStatus.Live;

        /// <summary>
        /// Gets the link target, either the external address or the path on this website.
        /// </summary>
        public string? Href => Url?.ToString() ?? Path;

        /// <summary>
        /// Gets the short location shown next to the link.
        /// </summary>
        public string? LinkLabel => Url?.Host ?? Path;

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Url is not null && Path is not null)
            {
                yield return new ValidationResult(
                    $"Only one of the {nameof(Url)} and {nameof(Path)} fields may be set.",
                    [nameof(Url), nameof(Path)]);
            }

            if (Path is not null && (!Path.StartsWith(PathSeparator) || Path.StartsWith(ProtocolRelativePrefix, StringComparison.Ordinal)))
            {
                yield return new ValidationResult(
                    $"The {nameof(Path)} field must be a root-relative path on this website.",
                    [nameof(Path)]);
            }

            if (Url is null)
            {
                if (IsLive && Path is null)
                {
                    yield return new ValidationResult(
                        $"The {nameof(Url)} or {nameof(Path)} field is required while the subsite is {nameof(SubsiteStatus.Live)}.",
                        [nameof(Url), nameof(Path)]);
                }

                yield break;
            }

            var isWebAddress = Url.IsAbsoluteUri
                && (Url.Scheme == Uri.UriSchemeHttps || Url.Scheme == Uri.UriSchemeHttp);

            if (!isWebAddress)
            {
                yield return new ValidationResult(
                    $"The {nameof(Url)} field must be an absolute http or https address.",
                    [nameof(Url)]);
            }
        }
    }
}
