using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using MultiShop.WebUI.Languages;

namespace MultiShop.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        readonly IStringLocalizer<Lang> _stringLocalizer;
        private readonly RequestLocalizationOptions _requestLocalizationOptions;

        public PaymentController(IStringLocalizer<Lang> stringLocalizer, IOptions<RequestLocalizationOptions> requestLocalizationOptions)
        {
            _stringLocalizer = stringLocalizer;
            _requestLocalizationOptions = requestLocalizationOptions.Value;
        }

        public IActionResult Index()
        {
            var paymentScreen = _stringLocalizer["inPage.PaymentScreen"];
            var paymentByCard = _stringLocalizer["inPage.PaymentbyCard"];

            ViewBag.directory1 = "MultiShop";
            ViewBag.directory2 = paymentScreen;
            ViewBag.directory3 = paymentByCard;

            return View();
        }
    }
}
