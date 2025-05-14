using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDto;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MultiShop.WebUI.ViewComponents.ProuductDetailViewComponents
{
    public class _ProductDetailFeatureComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseCategoryMesasge = await client.GetAsync($"https://localhost:44320/api/Products/{id}");
            if (responseCategoryMesasge.IsSuccessStatusCode)
            {
                var jsonData = await responseCategoryMesasge.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);
                return View(values);
            }
                return View();
        }
    }
}
