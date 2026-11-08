namespace Veritatron.Web
{
    /// <summary>
    /// External addresses of the words2widget product page.
    /// </summary>
    public static class Words2WidgetLinks
    {
        /// <summary>
        /// The source repository.
        /// </summary>
        public const string Repository = $"{SiteLinks.GitHub}/words2widget";

        /// <summary>
        /// The Scriptable app in the App Store.
        /// </summary>
        public const string Scriptable = "https://apps.apple.com/app/scriptable/id1405459188";

        /// <summary>
        /// The prompt for ChatGPT, Gemini and other assistants.
        /// </summary>
        public const string Prompt = $"{Repository}/blob/master/PROMPT.md";

        /// <summary>
        /// The downloadable skill for Claude.
        /// </summary>
        public const string ClaudeSkill = $"{Repository}/releases/latest/download/scriptable-widget.zip";
    }
}
