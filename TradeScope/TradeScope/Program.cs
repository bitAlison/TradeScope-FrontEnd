using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;

using TradeScope.Domain.Services.Contracts;
using TradeScope.Infrastructure.Repositories;
using TradeScope.Localization;
using TradeScope.Services;
using TradeScope.Infrastructure;
using TradeScope.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TradeScopeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositórios
builder.Services.AddScoped<CryptoRepository>();
builder.Services.AddScoped<IndexRepository>();
builder.Services.AddScoped<CommoditieRepository>();
builder.Services.AddScoped<B3StockRepository>();
builder.Services.AddScoped<ForexRepository>();

//builder.Services.AddScoped<AssetRepository>();


//Serviços Db
//builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<ICryptoService, CryptoService>();
builder.Services.AddScoped<IIndexService, IndexService>();
builder.Services.AddScoped<ICommoditieService, CommoditieService>();
builder.Services.AddScoped<IB3StockService, B3StockService>();
builder.Services.AddScoped<IForexService, ForexService>();


// Serviços do domínio
builder.Services.AddSingleton<IRiskCalculator, RiskCalculator>();
builder.Services.AddSingleton<ITranslationService, SimpleTranslationService>();
builder.Services.AddSingleton<ITradeMetricsService, TradeMetricsService>();
builder.Services.AddSingleton<IOperationsService, OperationsService>();
builder.Services.AddScoped<ISettingsService, SettingsService>();
//builder.Services.AddSingleton<ITradeStore, JsonTradeStore>();

// Necessário para cultura no SimpleTranslationService
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Culturas suportadas
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
    DefaultRequestCulture = new RequestCulture("en"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
};

localizationOptions.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider());
localizationOptions.RequestCultureProviders.Insert(1, new QueryStringRequestCultureProvider());

app.UseRequestLocalization(localizationOptions);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Static assets (ok manter como está no repo)
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
