using MudBlazor.Services;
using Veritatron.Web;
using Veritatron.Web.Components;
using Veritatron.Web.Configuration;
using Veritatron.Web.Localization;
using Veritatron.Web.Theme;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices();
builder.Services.AddLocalization();
builder.Services.AddSingleton(TimeProvider.System);
builder.Services.AddRazorComponents();
builder.AddValidatedOptions<SubsitesOptions>();
builder.AddValidatedOptions<LegalOptions>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(SitePaths.Error, createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute(SitePaths.NotFound, createScopeForStatusCodePages: true);

app.UseHttpsRedirection();

app.UseRequestLocalization(options =>
{
    string[] cultures = [.. SupportedCultures.All];
    options.SetDefaultCulture(SupportedCultures.Default)
        .AddSupportedCultures(cultures)
        .AddSupportedUICultures(cultures);
});

app.UseAntiforgery();

app.MapStaticAssets();
app.MapGet(SitePaths.Favicon, () => Results.Content(FaviconSvg.Content, FaviconSvg.ContentType));
app.MapRazorComponents<App>();

app.Run();
