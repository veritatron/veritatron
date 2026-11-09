using System.ComponentModel.DataAnnotations;

namespace Veritatron.Web.Configuration
{
    /// <summary>
    /// The provider details shown on the legal pages, kept out of the public source code.
    /// </summary>
    public class LegalOptions : IValidatedOptions
    {
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public static string SectionName => "Legal";

        /// <summary>
        /// Gets or sets the full name of the provider.
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the street and house number.
        /// </summary>
        [Required]
        public string Street { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the postal code and city.
        /// </summary>
        [Required]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the contact email address.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
