using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _OfferDiscountDefaultComponentPartial : ViewComponent
    {
        private readonly IOfferDiscountServices _offerDiscountServices;

        public _OfferDiscountDefaultComponentPartial(IOfferDiscountServices offerDiscountServices)
        {
            _offerDiscountServices = offerDiscountServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _offerDiscountServices.GetAllOfferDiscountAsync();
            return View(values);
        }
    }
}
