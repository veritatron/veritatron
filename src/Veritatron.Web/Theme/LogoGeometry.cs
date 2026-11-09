namespace Veritatron.Web.Theme
{
    /// <summary>
    /// Geometry of the Veritatron mark: two strokes converging into a V, the left one set lower, the right one higher.
    /// </summary>
    public static class LogoGeometry
    {
        /// <summary>
        /// Origin of the square view box on both axes.
        /// </summary>
        public const string ViewBoxOrigin = "200";

        /// <summary>
        /// Edge length of the square view box.
        /// </summary>
        public const string ViewBoxSize = "680";

        /// <summary>
        /// SVG view box that frames the mark.
        /// </summary>
        public const string ViewBox = $"{ViewBoxOrigin} {ViewBoxOrigin} {ViewBoxSize} {ViewBoxSize}";

        /// <summary>
        /// Polygon points of the left, lower stroke.
        /// </summary>
        public const string LeftStroke = "215,270 375,270 528,695 528,880 435,880";

        /// <summary>
        /// Polygon points of the right, higher stroke.
        /// </summary>
        public const string RightStroke = "865,210 705,210 552,635 552,820 645,820";
    }
}
