using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.ProductDto;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductImageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductImageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ProductImageListDetail(string id)
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

        [HttpGet]
        public async Task<IActionResult> ProductImageDetail(string id)
        {

            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Görsel Güncelleme Sayfası";
            ViewBag.v0 = "Ürün Görsel İşlemleri";

            var client = _httpClientFactory.CreateClient();
            //var responseCategoryMesasge = await client.GetAsync("https://localhost:44320/api/Categories");
            //if (responseCategoryMesasge.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseCategoryMesasge.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            //    List<SelectListItem> categoryValues = (from x in values
            //                                           select new SelectListItem
            //                                           {
            //                                               Text = x.CategoryName,
            //                                               Value = x.CategoryID.ToString()
            //                                           }).ToList();
            //    ViewBag.CategoryValues = categoryValues;
            //}

            var responseMesasge = await client.GetAsync($"https://localhost:44320/api/ProductImages/{id}");
            if (responseMesasge.IsSuccessStatusCode)
            {
                var jsonData = await responseMesasge.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductImageDetail(UpdateProductImageDto updateProductImageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductImageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44320/api/ProductImages", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductImageListDetail", "ProductImage", new {id = updateProductImageDto.ProductID, area = "Admin" });
            }
            return View();
        }
    }
}
