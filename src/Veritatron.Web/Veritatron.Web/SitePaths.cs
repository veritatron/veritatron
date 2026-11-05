namespace Veritatron.Web
{
    /// <summary>
    /// Routes, endpoints and in-page anchors of the website.
    /// </summary>
    public static class SitePaths
    {
        /// <summary>
        /// The start page.
        /// </summary>
        public const string Home = "/";

        /// <summary>
        /// The legal notice required by German law.
        /// </summary>
        public const string Imprint = "/impressum";

        /// <summary>
        /// The privacy policy.
        /// </summary>
        public const string Privacy = "/datenschutz";

        /// <summary>
        /// The page shown for unknown addresses.
        /// </summary>
        public const string NotFound = "/not-found";

        /// <summary>
        /// The page shown for unhandled errors.
        /// </summary>
        public const string Error = "/error";

        /// <summary>
        /// The generated favicon.
        /// </summary>
        public const string Favicon = "/favicon.svg";

        /// <summary>
        /// Element id of the main content, target of the skip link.
        /// </summary>
        public const string MainContentId = "inhalt";

        /// <summary>
        /// Element id of the projects section on the start page.
        /// </summary>
        public const string ProjectsSectionId = "projekte";

        /// <summary>
        /// Element id of the about section on the start page.
        /// </summary>
        public const string AboutSectionId = "ueber";

        /// <summary>
        /// Link to the projects section from any page.
        /// </summary>
        public const string Projects = $"{Home}#{ProjectsSectionId}";

        /// <summary>
        /// Link to the about section from any page.
        /// </summary>
        public const string About = $"{Home}#{AboutSectionId}";
    }
}
