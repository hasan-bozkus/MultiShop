using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailsDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductDetailController : Controller
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
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

            var values = await _productDetailService.GetByProductIDProductDetailAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateProductDetail(GetByIDProductDetailDto updateProductDetailDto, CreateProductDetailDto createProductDetailDto, string id)
        {
            updateProductDetailDto.ProductID = id;
            createProductDetailDto.ProductID = id;

            if(!ModelState.IsValid || string.IsNullOrEmpty(updateProductDetailDto.ProductDetailID))
            {
                await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
                    return RedirectToAction("ProductListWithCategory", "Product", new {area = "Admin"});

            }

            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
        }
    }
}
