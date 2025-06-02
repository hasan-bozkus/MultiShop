using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OfferDiscountController : Controller
    {
        private readonly IOfferDiscountServices _offerDiscountServices;

        public OfferDiscountController(IOfferDiscountServices offerDiscountServices)
        {
            _offerDiscountServices = offerDiscountServices;
        }

        void OfferDiscountViewBag()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklif Listesi";
            ViewBag.v0 = "İndirim Teklif İşlemleri";
        }

        public async Task<IActionResult> Index()
        {
            OfferDiscountViewBag();

            var values = await _offerDiscountServices.GetAllOfferDiscountAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateOfferDiscount()
        {
            OfferDiscountViewBag();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountServices.CreateOfferDiscountAsync(createOfferDiscountDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
           await _offerDiscountServices.DeleteOfferDiscountAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            OfferDiscountViewBag();

            var value = await _offerDiscountServices.GetByIDOfferDiscountAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountServices.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return RedirectToAction("Index");
        }
    }
}
