namespace Veritatron.Web.Localization
{
    /// <summary>
    /// Cultures the website is translated into. The neutral resources are German.
    /// </summary>
    public static class SupportedCultures
    {
        /// <summary>
        /// German, the default culture.
        /// </summary>
        public const string German = "de";

        /// <summary>
        /// The culture used when the request asks for none of the supported ones.
        /// </summary>
        public const string Default = German;

        /// <summary>
        /// Gets all supported cultures.
        /// </summary>
        public static IReadOnlyList<string> All { get; } = [German];
    }
}
