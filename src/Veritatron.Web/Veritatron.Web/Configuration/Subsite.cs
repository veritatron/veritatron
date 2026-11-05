using System.ComponentModel.DataAnnotations;

namespace Veritatron.Web.Configuration
{
    /// <summary>
    /// A website or application Veritatron links to.
    /// </summary>
    public class Subsite : IValidatableObject
    {
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a short description of one or two sentences.
        /// </summary>
        [Required]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets whether the subsite is online or announced as a preview.
        /// </summary>
        public SubsiteStatus Status { get; set; } = SubsiteStatus.Live;

        /// <summary>
        /// Gets or sets the absolute HTTP or HTTPS address. Required while the subsite is live.
        /// </summary>
        public Uri? Url { get; set; }

        /// <summary>
        /// Gets whether the subsite is online and can be linked.
        /// </summary>
        public bool IsLive => Status == SubsiteStatus.Live;

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Url is null)
            {
                if (IsLive)
                {
                    yield return new ValidationResult(
                        $"The {nameof(Url)} field is required while the subsite is {nameof(SubsiteStatus.Live)}.",
                        [nameof(Url)]);
                }

                yield break;
            }

            var isWebAddress = Url.IsAbsoluteUri
                && (Url.Scheme == Uri.UriSchemeHttps || Url.Scheme == Uri.UriSchemeHttp);

            if (!isWebAddress)
            {
                yield return new ValidationResult(
                    $"The {nameof(Url)} field must be an absolute http or https address.",
                    [nameof(Url)]);
            }
        }
    }
}
