using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.ProductDto;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductImageController : Controller
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<IActionResult> ProductImageListDetail(string id)
        {
            var values = await _productImageService.GetByProductIDProdutsImageListAsync(id);
            ViewBag.productId = id;

            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageDetail(string id)
        {

            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Görsel Güncelleme Sayfası";
            ViewBag.v0 = "Ürün Görsel İşlemleri";

            //var client = _httpClientFactory.CreateClient();
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
            var values = await _productImageService.GetByIDProductImageAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> ProductImageDetail(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return RedirectToAction("ProductImageListDetail");
        }

        [HttpGet]
        public async Task<IActionResult> CreateProductImageDetail(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Görsel Ekleme Sayfası";
            ViewBag.v0 = "Ürün Görsel İşlemleri";
            ViewBag.productId = id;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImageDetail(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return RedirectToAction("ProductImageListDetail", "ProductImage", new { id = createProductImageDto.ProductID, area = "Admin" });
        }

        public async Task<IActionResult> ProductImageDeatilDelete(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return RedirectToAction("ProductListWithCategory", "Product", new {area = "Admin" });

        }
    }
}
