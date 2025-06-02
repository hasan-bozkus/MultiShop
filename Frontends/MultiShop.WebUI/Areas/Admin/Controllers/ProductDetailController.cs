using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailsDtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrUpdateProductDetail(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Açıklama ve Bilgi Güncelleme Sayfası";
            ViewBag.v0 = "Ürün İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMesasge = await client.GetAsync($"https://localhost:44320/api/ProductDetails/GetProductDetailByProductId/{id}");
            if (responseMesasge.IsSuccessStatusCode)
            {
                var jsonData = await responseMesasge.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateProductDetail(UpdateProductDetailDto updateProductDetailDto, CreateProductDetailDto createProductDetailDto, string id)
        {
            updateProductDetailDto.ProductID = id;
            createProductDetailDto.ProductID = id;

            var client = _httpClientFactory.CreateClient();
            if(!ModelState.IsValid || string.IsNullOrEmpty(updateProductDetailDto.ProductDetailID))
            {
                var jsonCreateData = JsonConvert.SerializeObject(createProductDetailDto);
                StringContent stringCreateContent = new StringContent(jsonCreateData, Encoding.UTF8, "application/json");
                var responseCreateMessage = await client.PostAsync("https://localhost:44320/api/ProductDetails", stringCreateContent);
                if (responseCreateMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("ProductListWithCategory", "Product", new {area = "Admin"});
                }
            }
            var jsonData = JsonConvert.SerializeObject(updateProductDetailDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44320/api/ProductDetails", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
