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
        /// The product page of words2widget.
        /// </summary>
        public const string Words2Widget = "/words2widget";

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
        /// Element id of the quickstart section on the words2widget page.
        /// </summary>
        public const string QuickstartSectionId = "schnellstart";

        /// <summary>
        /// Element id of the ideas section on the words2widget page.
        /// </summary>
        public const string IdeasSectionId = "ideen";

        /// <summary>
        /// Element id of the frequently asked questions on the words2widget page.
        /// </summary>
        public const string FaqSectionId = "fragen";

        /// <summary>
        /// Link to the quickstart section of the words2widget page.
        /// </summary>
        public const string Words2WidgetQuickstart = $"{Words2Widget}#{QuickstartSectionId}";

        /// <summary>
        /// Link to the ideas section of the words2widget page.
        /// </summary>
        public const string Words2WidgetIdeas = $"{Words2Widget}#{IdeasSectionId}";

        /// <summary>
        /// Link to the frequently asked questions of the words2widget page.
        /// </summary>
        public const string Words2WidgetFaq = $"{Words2Widget}#{FaqSectionId}";

        /// <summary>
        /// Element id of the focus areas section on the start page.
        /// </summary>
        public const string FocusSectionId = "schwerpunkte";

        /// <summary>
        /// Element id of the news section on the start page.
        /// </summary>
        public const string NewsSectionId = "neuigkeiten";

        /// <summary>
        /// Link to the focus areas section from any page.
        /// </summary>
        public const string Focus = $"{Home}#{FocusSectionId}";

        /// <summary>
        /// Link to the news section from any page.
        /// </summary>
        public const string News = $"{Home}#{NewsSectionId}";

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
