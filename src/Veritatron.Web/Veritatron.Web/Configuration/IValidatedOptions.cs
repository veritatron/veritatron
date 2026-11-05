namespace Veritatron.Web.Configuration
{
    /// <summary>
    /// Options that are bound to a configuration section and validated when the application starts.
    /// </summary>
    public interface IValidatedOptions
    {
        /// <summary>
        /// Gets the configuration section the options are bound to.
        /// </summary>
        public static abstract string SectionName { get; }
    }
}
