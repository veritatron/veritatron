namespace Veritatron.Web.Configuration
{
    /// <summary>
    /// Registration of options that are validated on start.
    /// </summary>
    public static class ValidatedOptionsExtensions
    {
        /// <summary>
        /// Binds <typeparamref name="TOptions"/> to its configuration section, validates its data annotations
        /// and stops the application on start if the configuration is invalid.
        /// </summary>
        public static IHostApplicationBuilder AddValidatedOptions<TOptions>(this IHostApplicationBuilder builder)
            where TOptions : class, IValidatedOptions
        {
            ArgumentNullException.ThrowIfNull(builder);

            builder.Services.AddOptions<TOptions>()
                .BindConfiguration(TOptions.SectionName)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            return builder;
        }
    }
}
