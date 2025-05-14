using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MultiShop.WebUI.ViewComponents.ProuductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailImageSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseCategoryMesasge = await client.GetAsync($"https://localhost:44320/api/ProductImages/ProdctImageListByProductID/{id}");
            if (responseCategoryMesasge.IsSuccessStatusCode)
            {
                var jsonData = await responseCategoryMesasge.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetByIDProductImageDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
