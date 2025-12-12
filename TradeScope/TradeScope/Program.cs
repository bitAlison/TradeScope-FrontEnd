using System.Globalization;
using Microsoft.AspNetCore.Localization;

using TradeScope.Domain.Services.Contracts;
using TradeScope.Localization;
using TradeScope.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();

builder.Services.AddScoped<IRiskCalculator, RiskCalculator>();
builder.Services.AddScoped<ITranslationService, SimpleTranslationService>();

// Necessário para ler cultura do HttpContext
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Cultures
var supportedCultures = new[]
{
    new CultureInfo("en"),
    new CultureInfo("pt"),
    new CultureInfo("es"),
    new CultureInfo("zh"),
    new CultureInfo("hi"),
    new CultureInfo("ar"),
    new CultureInfo("ru")
};

var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en"), // default global
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
};

// Suporte a cookie + querystring (ex: ?culture=pt)
localizationOptions.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider());
localizationOptions.RequestCultureProviders.Insert(1, new QueryStringRequestCultureProvider());

app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// *** Do not use it in Azure ***
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
