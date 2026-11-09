namespace Veritatron.Web.Theme
{
    /// <summary>
    /// The favicon, generated from the logo geometry and the brand colors so no color value lives in a file.
    /// </summary>
    public static class FaviconSvg
    {
        /// <summary>
        /// Media type of the favicon.
        /// </summary>
        public const string ContentType = "image/svg+xml";

        private const string CornerRadius = "136";
        private const string MarkInset = "108";
        private const string MarkScale = "0.8";

        /// <summary>
        /// The SVG document: the mark on a rounded charcoal square.
        /// </summary>
        public const string Content =
            $"<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"{LogoGeometry.ViewBox}\">"
            + $"<rect x=\"{LogoGeometry.ViewBoxOrigin}\" y=\"{LogoGeometry.ViewBoxOrigin}\" width=\"{LogoGeometry.ViewBoxSize}\" height=\"{LogoGeometry.ViewBoxSize}\" rx=\"{CornerRadius}\" fill=\"{VeritatronColors.Charcoal}\"/>"
            + $"<g transform=\"translate({MarkInset} {MarkInset}) scale({MarkScale})\">"
            + $"<polygon points=\"{LogoGeometry.LeftStroke}\" fill=\"{VeritatronColors.SignalYellow}\"/>"
            + $"<polygon points=\"{LogoGeometry.RightStroke}\" fill=\"{VeritatronColors.Paper}\"/>"
            + "</g></svg>";
    }
}
