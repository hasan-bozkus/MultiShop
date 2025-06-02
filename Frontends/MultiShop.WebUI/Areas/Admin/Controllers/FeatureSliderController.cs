using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDto;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureSliderController : Controller
    {
        private readonly ISliderFeatureService _sliderFeatureService;

        public FeatureSliderController(ISliderFeatureService sliderFeatureService)
        {
            _sliderFeatureService = sliderFeatureService;
        }

        void SliderFeatureViewBag()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkan Görseller";
            ViewBag.v3 = "Öne Çıkan Göresller Listesi";
            ViewBag.v0 = "Öne Çıkan Görseller İşlemleri";
        }

        public async Task<IActionResult> Index()
        {
            SliderFeatureViewBag();

            var values = await _sliderFeatureService.GetAllFeatureSliderAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateFeatureSlider()
        {
            SliderFeatureViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
           await _sliderFeatureService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _sliderFeatureService.DeleteFeatureSliderAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {

            SliderFeatureViewBag();
            var values = await _sliderFeatureService.GetByIDFeatureSliderAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _sliderFeatureService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return RedirectToAction("Index");
        }
    }
}
