// Delegated, so buttons keep working after Blazor's enhanced navigation swaps the page content.
const RESET_DELAY_MS = 2500;

document.addEventListener("click", async (event) => {
    const button = event.target.closest("[data-copy-target]");
    if (!button) {
        return;
    }

    const source = document.getElementById(button.dataset.copyTarget);
    const label = button.querySelector("[data-copy-label]");
    if (!source || !label) {
        return;
    }

    label.dataset.defaultText ??= label.textContent;

    try {
        // Must be the first awaited call: iOS only allows copying directly inside the tap.
        await navigator.clipboard.writeText(source.textContent);
        label.textContent = button.dataset.copySuccess;
    } catch {
        label.textContent = button.dataset.copyFailure;
        source.closest("details")?.setAttribute("open", "");
    }

    clearTimeout(Number(label.dataset.resetTimer));
    label.dataset.resetTimer = setTimeout(() => {
        label.textContent = label.dataset.defaultText;
    }, RESET_DELAY_MS);
});
