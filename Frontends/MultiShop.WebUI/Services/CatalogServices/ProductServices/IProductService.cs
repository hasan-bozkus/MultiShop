using MultiShop.DtoLayer.CatalogDtos.ProductDto;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(ResultProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<ResultProductDto> GetByIDProductAsync(string id);
        Task<List<ResultProductWithCategoryDto>> GetResultProductWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryByCategoryIdAsync(string categoryId);
    }
}
