using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailsDtos;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MultiShop.WebUI.ViewComponents.ProuductDetailViewComponents
{
    public class _ProductDetailDescriptionComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailDescriptionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseCategoryMesasge = await client.GetAsync($"https://localhost:44320/api/ProductDetails/GetProductDetailByProductId/{id}");
            if (responseCategoryMesasge.IsSuccessStatusCode)
            {
                var jsonData = await responseCategoryMesasge.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetByIDProductDetailDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
