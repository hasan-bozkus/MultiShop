using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailsDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDeatilDeatilsController : ControllerBase
    {
        private readonly IProductDetailService _productDeatilService;

        public ProductDeatilDeatilsController(IProductDetailService productDeatilService)
        {
            _productDeatilService = productDeatilService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDeatilList()
        {
            var categories = await _productDeatilService.GetAllProductDetailAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDeatilByID(string id)
        {
            var values = await _productDeatilService.GetByIDProductDetailAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDeatil(CreateProductDetailDto createProductDeatilDto)
        {
            await _productDeatilService.CreateProductDetailAsync(createProductDeatilDto);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDeatil(string id)
        {
            await _productDeatilService.DeleteProductDetailAsync(id);
            return Ok("Silme işlemi başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDeatil(UpdateProductDetailDto updateProductDeatilDto)
        {
            await _productDeatilService.UpdateProductDetailAsync(updateProductDeatilDto);
            return Ok("Güncelleme işlemi başarılı");
        }
    }
}
