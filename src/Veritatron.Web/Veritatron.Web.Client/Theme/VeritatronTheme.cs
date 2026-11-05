using MudBlazor;

namespace Veritatron.Web.Client.Theme
{
    /// <summary>
    /// The MudBlazor theme of Veritatron. It maps the brand colors to MudBlazor's palette roles and sets typography and shape.
    /// </summary>
    public static class VeritatronTheme
    {
        private const string BrandFontFamily = "Space Grotesk";
        private const string FallbackFontFamily = "sans-serif";
        private const string BorderRadius = "8px";

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
                AppbarBackground = VeritatronColors.Charcoal,
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
                Default = new DefaultTypography { FontFamily = _fontFamilies },
                H1 = new H1Typography { FontFamily = _fontFamilies },
                H2 = new H2Typography { FontFamily = _fontFamilies },
                H3 = new H3Typography { FontFamily = _fontFamilies },
                H4 = new H4Typography { FontFamily = _fontFamilies },
                H5 = new H5Typography { FontFamily = _fontFamilies },
                H6 = new H6Typography { FontFamily = _fontFamilies },
                Subtitle1 = new Subtitle1Typography { FontFamily = _fontFamilies },
                Subtitle2 = new Subtitle2Typography { FontFamily = _fontFamilies },
                Body1 = new Body1Typography { FontFamily = _fontFamilies },
                Body2 = new Body2Typography { FontFamily = _fontFamilies },
                Button = new ButtonTypography { FontFamily = _fontFamilies },
                Caption = new CaptionTypography { FontFamily = _fontFamilies },
                Overline = new OverlineTypography { FontFamily = _fontFamilies },
            },
            LayoutProperties = new LayoutProperties { DefaultBorderRadius = BorderRadius },
        };
    }
}
