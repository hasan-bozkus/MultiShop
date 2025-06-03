using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDto;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial : ViewComponent
    {
        private readonly ISliderFeatureService _sliderFeatureService;

        public _CarouselDefaultComponentPartial(ISliderFeatureService sliderFeatureService)
        {
            _sliderFeatureService = sliderFeatureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           var values = await _sliderFeatureService.GetAllFeatureSliderAsync();
           return View(values);
        }
    }
}
