using MudBlazor;

namespace Veritatron.Web.Theme
{
    /// <summary>
    /// The MudBlazor theme of Veritatron. It maps the brand colors to MudBlazor's palette roles
    /// and defines the type scale and shape. Every value here is a design token in exactly one place.
    /// </summary>
    public static class VeritatronTheme
    {
        private const string BrandFontFamily = "Space Grotesk";
        private const string FallbackFontFamily = "sans-serif";
        private const string BorderRadius = "8px";

        private const string WeightRegular = "400";
        private const string WeightMedium = "500";
        private const string WeightSemiBold = "600";
        private const string WeightBold = "700";

        private const string NoTextTransform = "none";
        private const string Uppercase = "uppercase";

        private static readonly string[] _fontFamilies = [BrandFontFamily, FallbackFontFamily];

        /// <summary>
        /// Gets the theme. Veritatron is dark only, because the logo is designed for a dark background.
        /// </summary>
        public static MudTheme Instance { get; } = new()
        {
            PaletteDark = new PaletteDark
            {
                Primary = VeritatronColors.SignalYellow,
                PrimaryContrastText = VeritatronColors.Charcoal,
                Secondary = VeritatronColors.Paper,
                SecondaryContrastText = VeritatronColors.Charcoal,
                Background = VeritatronColors.Charcoal,
                Surface = VeritatronColors.CharcoalRaised,
                AppbarBackground = VeritatronColors.CharcoalTranslucent,
                AppbarText = VeritatronColors.Paper,
                DrawerBackground = VeritatronColors.CharcoalRaised,
                DrawerText = VeritatronColors.Paper,
                TextPrimary = VeritatronColors.Paper,
                TextSecondary = VeritatronColors.PaperMuted,
                Divider = VeritatronColors.PaperLine,
                LinesDefault = VeritatronColors.PaperLine,
            },
            Typography = new Typography
            {
                Default = new DefaultTypography
                {
                    FontFamily = _fontFamilies,
                    FontSize = "1.0625rem",
                    FontWeight = WeightRegular,
                    LineHeight = "1.65",
                    LetterSpacing = "0",
                },
                H1 = new H1Typography
                {
                    FontFamily = _fontFamilies,
                    FontSize = "3.5rem",
                    FontWeight = WeightBold,
                    LineHeight = "1.05",
                    LetterSpacing = "-0.035em",
                },
                H2 = new H2Typography
                {
                    FontFamily = _fontFamilies,
                    FontSize = "2.5rem",
                    FontWeight = WeightBold,
                    LineHeight = "1.1",
                    LetterSpacing = "-0.03em",
                },
                H3 = new H3Typography
                {
                    FontFamily = _fontFamilies,
                    FontSize = "2rem",
                    FontWeight = WeightBold,
                    LineHeight = "1.15",
                    LetterSpacing = "-0.02em",
                },
                H4 = new H4Typography
                {
                    FontFamily = _fontFamilies,
                    FontSize = "1.5rem",
                    FontWeight = WeightSemiBold,
                    LineHeight = "1.25",
                    LetterSpacing = "-0.015em",
                },
                H5 = new H5Typography
                {
                    FontFamily = _fontFamilies,
                    FontSize = "1.25rem",
                    FontWeight = WeightSemiBold,
                    LineHeight = "1.3",
                    LetterSpacing = "-0.01em",
                },
                H6 = new H6Typography
                {
                    FontFamily = _fontFamilies,
                    FontSize = "1.0625rem",
                    FontWeight = WeightSemiBold,
                    LineHeight = "1.4",
                    LetterSpacing = "0",
                },
                Subtitle1 = new Subtitle1Typography
                {
                    FontFamily = _fontFamilies,
                    FontSize = "1.25rem",
                    FontWeight = WeightRegular,
                    LineHeight = "1.6",
                    LetterSpacing = "0",
                },
                Subtitle2 = new Subtitle2Typography
                {
                    FontFamily = _fontFamilies,
                    FontSize = "0.9375rem",
                    FontWeight = WeightMedium,
                    LineHeight = "1.5",
                    LetterSpacing = "0",
                },
                Body1 = new Body1Typography
                {
                    FontFamily = _fontFamilies,
                    FontSize = "1.0625rem",
                    FontWeight = WeightRegular,
                    LineHeight = "1.65",
                    LetterSpacing = "0",
                },
                Body2 = new Body2Typography
                {
                    FontFamily = _fontFamilies,
                    FontSize = "0.9375rem",
                    FontWeight = WeightRegular,
                    LineHeight = "1.6",
                    LetterSpacing = "0",
                },
                Button = new ButtonTypography
                {
                    FontFamily = _fontFamilies,
                    FontSize = "0.9375rem",
                    FontWeight = WeightSemiBold,
                    LineHeight = "1.75",
                    LetterSpacing = "0",
                    TextTransform = NoTextTransform,
                },
                Caption = new CaptionTypography
                {
                    FontFamily = _fontFamilies,
                    FontSize = "0.8125rem",
                    FontWeight = WeightRegular,
                    LineHeight = "1.5",
                    LetterSpacing = "0.01em",
                },
                Overline = new OverlineTypography
                {
                    FontFamily = _fontFamilies,
                    FontSize = "0.75rem",
                    FontWeight = WeightSemiBold,
                    LineHeight = "1.5",
                    LetterSpacing = "0.16em",
                    TextTransform = Uppercase,
                },
            },
            LayoutProperties = new LayoutProperties { DefaultBorderRadius = BorderRadius },
        };
    }
}
