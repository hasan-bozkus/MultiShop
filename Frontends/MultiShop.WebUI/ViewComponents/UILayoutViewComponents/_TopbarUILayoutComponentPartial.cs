using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using MultiShop.WebUI.Languages;
using System.Globalization;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _TopbarUILayoutComponentPartial : ViewComponent
    {
        protected readonly IList<CultureInfo> _supportedCultures;
        private readonly IStringLocalizer<Lang> _stringLocalizer;
        private readonly RequestLocalizationOptions _requestLocalizationOptions;

        public _TopbarUILayoutComponentPartial(IOptions<RequestLocalizationOptions> localizationOptions, IStringLocalizer<Lang> stringLocalizer)
        {
            _supportedCultures = localizationOptions.Value.SupportedCultures;
            _requestLocalizationOptions = localizationOptions.Value;
            _stringLocalizer = stringLocalizer;
        }
        public IViewComponentResult Invoke()
        {
            //Customer service
            ViewBag.InPageCustomerService = _stringLocalizer["inPage.CustomerService"];
            ViewBag.InPageEntertheProducttoSearch = _stringLocalizer["inPage.EntertheProducttoSearch"];
            return View(_supportedCultures);
        }
    }
}
