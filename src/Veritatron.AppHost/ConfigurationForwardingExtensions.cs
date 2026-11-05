using Microsoft.Extensions.Configuration;

namespace Veritatron.AppHost
{
    /// <summary>
    /// Forwards configuration of the AppHost to a resource as environment variables.
    /// </summary>
    public static class ConfigurationForwardingExtensions
    {
        private const string EnvironmentKeyDelimiter = "__";

        /// <summary>
        /// Passes every value of <paramref name="sectionName"/> to the resource as an environment variable,
        /// for example <c>Subsites:Items:0:Name</c> as <c>Subsites__Items__0__Name</c>.
        /// </summary>
        public static IResourceBuilder<TResource> WithConfigurationSection<TResource>(
            this IResourceBuilder<TResource> resource,
            IConfiguration configuration,
            string sectionName)
            where TResource : IResourceWithEnvironment
        {
            ArgumentNullException.ThrowIfNull(resource);
            ArgumentNullException.ThrowIfNull(configuration);

            foreach (var (key, value) in configuration.GetSection(sectionName).AsEnumerable())
            {
                if (value is null)
                {
                    continue;
                }

                var environmentKey = key.Replace(ConfigurationPath.KeyDelimiter, EnvironmentKeyDelimiter, StringComparison.Ordinal);
                resource.WithEnvironment(environmentKey, value);
            }

            return resource;
        }
    }
}
