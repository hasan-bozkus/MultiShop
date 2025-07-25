using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using MultiShop.WebUI.Languages;

namespace MultiShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        readonly IStringLocalizer<Lang> _stringLocalizer;
        private readonly RequestLocalizationOptions _requestLocalizationOptions;

        public DefaultController(IStringLocalizer<Lang> stringLocalizer, IOptions<RequestLocalizationOptions> requestLocalizationOptions)
        {
            _stringLocalizer = stringLocalizer;
            _requestLocalizationOptions = requestLocalizationOptions.Value;
        }

        public IActionResult Index()
        {
            var homePage = _stringLocalizer["inPage.HomePage"];
            var productList = _stringLocalizer["inPage.ProductList"];

            ViewBag.directory1 = "MultiShop";
            ViewBag.directory2 = homePage;
            ViewBag.directory3 = productList;

            return View();
        }
    }
}
