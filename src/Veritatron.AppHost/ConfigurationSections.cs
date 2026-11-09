namespace Veritatron.AppHost
{
    /// <summary>
    /// Configuration sections the AppHost forwards to the website. The names match the options sections of Veritatron.Web.
    /// </summary>
    public static class ConfigurationSections
    {
        /// <summary>
        /// The websites and applications Veritatron links to.
        /// </summary>
        public const string Subsites = "Subsites";

        /// <summary>
        /// The provider details shown on the legal pages.
        /// </summary>
        public const string Legal = "Legal";
    }
}
