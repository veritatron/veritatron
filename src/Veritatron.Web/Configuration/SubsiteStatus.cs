namespace Veritatron.Web.Configuration
{
    /// <summary>
    /// Availability of a subsite.
    /// </summary>
    public enum SubsiteStatus
    {
        /// <summary>
        /// The subsite is online and linked.
        /// </summary>
        Live,

        /// <summary>
        /// The subsite is announced as a preview and not linked yet.
        /// </summary>
        ComingSoon,
    }
}
