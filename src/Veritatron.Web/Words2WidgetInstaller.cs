using System.Reflection;

namespace Veritatron.Web
{
    /// <summary>
    /// The Widget Installer script shown and copied on the words2widget page.
    /// </summary>
    public static class Words2WidgetInstaller
    {
        private const string ResourceName = "Words2WidgetInstaller";
        private const string WindowsLineEnding = "\r\n";
        private const string UnixLineEnding = "\n";

        /// <summary>
        /// Gets the script with normalized line endings.
        /// </summary>
        public static string Code { get; } = ReadCode();

        private static string ReadCode()
        {
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(ResourceName)
                ?? throw new InvalidOperationException($"The embedded resource {ResourceName} is missing.");
            using var reader = new StreamReader(stream);

            return reader.ReadToEnd().Replace(WindowsLineEnding, UnixLineEnding, StringComparison.Ordinal).TrimEnd();
        }
    }
}
