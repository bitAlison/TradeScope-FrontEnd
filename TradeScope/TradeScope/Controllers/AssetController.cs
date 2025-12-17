using Microsoft.AspNetCore.Mvc;

using System.Text;
using System.Text.Json;

using TradeScope.Domain.Models;
using TradeScope.Domain.Services.Contracts;
using TradeScope.Helpers;

namespace TradeScope.Controllers
{
    public class AssetController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ICryptoService cryptoService;
        private readonly IIndexService indexService;
        private readonly ICommoditieService commoditieService;
        private readonly IB3StockService b3StockService;
        private readonly IForexService forexService;

        public AssetController(IWebHostEnvironment env, ICryptoService cryptoService, IIndexService indexService, ICommoditieService commoditieService, IB3StockService b3StockService, IForexService forexService)
        {
            _env = env;
            this.cryptoService = cryptoService;
            this.indexService = indexService;
            this.commoditieService = commoditieService;
            this.b3StockService = b3StockService;
            this.forexService = forexService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken = default)
        {
            var cryptos = await cryptoService.ListAllAsync(cancellationToken).ConfigureAwait(false);
            var commodities = await commoditieService.ListAllAsync(cancellationToken).ConfigureAwait(false);
            var indexes = await indexService.ListAllAsync(cancellationToken).ConfigureAwait(false);
            var b3stock = await b3StockService.ListAllAsync(cancellationToken).ConfigureAwait(false);
            var forex = await forexService.ListAllAsync(cancellationToken).ConfigureAwait(false);
            return View();
        }

        [HttpPost]
        public IActionResult Index(AssetModel model, string selectedAssetsJson)
        {

            string jsonToPersist;

            if (!string.IsNullOrWhiteSpace(selectedAssetsJson))
            {
                // Valida se é JSON válido antes de salvar (evita salvar lixo)
                using var _ = JsonDocument.Parse(selectedAssetsJson);
                jsonToPersist = JsonHelpers.PrettyJson(selectedAssetsJson);
            }
            else
            {
                jsonToPersist = JsonSerializer.Serialize(model, JsonHelpers.JsonOptions());
            }

            var dir = Path.Combine(_env.ContentRootPath, "App_Data", "asset");
            Directory.CreateDirectory(dir);

            // Nome do arquivo: ajuste conforme sua regra (por usuário, por ambiente, etc.)
            var filePath = Path.Combine(dir, "tradescope.asset.json");

            // Escrita atômica (evita arquivo corrompido em caso de crash)
            var tmp = filePath + ".tmp";
            System.IO.File.WriteAllText(tmp, jsonToPersist, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
            System.IO.File.Move(tmp, filePath, overwrite: true);

            var items = JsonSerializer.Deserialize<List<AssetItemModel>>(selectedAssetsJson ?? "[]");

            // Salvar no banco / validar / etc.

            return View(model);
        }
    }
}
