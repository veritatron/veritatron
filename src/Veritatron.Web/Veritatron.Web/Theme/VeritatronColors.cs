namespace Veritatron.Web.Theme
{
    /// <summary>
    /// Brand colors of Veritatron, taken from the logo. This is the only place where color values are defined.
    /// </summary>
    public static class VeritatronColors
    {
        /// <summary>
        /// Signal yellow of the left logo stroke and of "verita", the primary brand color.
        /// </summary>
        public const string SignalYellow = "#FFD400";

        /// <summary>
        /// Warm off-white of the right logo stroke and of "tron", used for text and as secondary color.
        /// </summary>
        public const string Paper = "#F7F5EF";

        /// <summary>
        /// Paper at 70 % opacity for secondary text.
        /// </summary>
        public const string PaperMuted = "#F7F5EFB3";

        /// <summary>
        /// Paper at 12 % opacity for dividers and outlines.
        /// </summary>
        public const string PaperLine = "#F7F5EF1F";

        /// <summary>
        /// Charcoal the logo is set on, used as page background.
        /// </summary>
        public const string Charcoal = "#212326";

        /// <summary>
        /// Charcoal at 80 % opacity for the header, which blurs the content scrolling behind it.
        /// </summary>
        public const string CharcoalTranslucent = "#212326CC";

        /// <summary>
        /// Slightly lighter charcoal for raised surfaces such as cards and drawers.
        /// </summary>
        public const string CharcoalRaised = "#2B2D31";
    }
}
