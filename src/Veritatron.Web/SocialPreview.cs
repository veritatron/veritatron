namespace Veritatron.Web
{
    /// <summary>
    /// Open Graph data for the link preview when the website is shared.
    /// </summary>
    public static class SocialPreview
    {
        /// <summary>
        /// Path of the preview image in wwwroot.
        /// </summary>
        public const string ImagePath = "/og-image.png";

        /// <summary>
        /// Width of the preview image in pixels.
        /// </summary>
        public const string ImageWidth = "1200";

        /// <summary>
        /// Height of the preview image in pixels.
        /// </summary>
        public const string ImageHeight = "630";

        /// <summary>
        /// Media type of the preview image.
        /// </summary>
        public const string ImageType = "image/png";

        /// <summary>
        /// Locale of the shared content in Open Graph notation.
        /// </summary>
        public const string Locale = "de_DE";
    }
}
