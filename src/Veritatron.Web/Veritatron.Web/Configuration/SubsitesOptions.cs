using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Veritatron.Web.Configuration
{
    /// <summary>
    /// The websites and applications Veritatron links to.
    /// Environment variables follow the pattern <c>Subsites__Items__0__Name</c>.
    /// </summary>
    public class SubsitesOptions : IValidatedOptions, IValidatableObject
    {
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public static string SectionName => "Subsites";

        /// <summary>
        /// Gets the subsites in display order. The list may be empty.
        /// </summary>
        public Collection<Subsite> Items { get; } = [];

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            for (var index = 0; index < Items.Count; index++)
            {
                var item = Items[index];
                var results = new List<ValidationResult>();
                Validator.TryValidateObject(item, new ValidationContext(item), results, validateAllProperties: true);

                var prefix = $"{nameof(Items)}[{index}]";
                foreach (var result in results)
                {
                    yield return new ValidationResult(
                        $"{prefix}: {result.ErrorMessage}",
                        result.MemberNames.Select(member => $"{prefix}.{member}"));
                }
            }
        }
    }
}
