using MultiShop.DtoLayer.CatalogDtos.ProductDetailsDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(GetByIDProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIDProductDetailDto> GetByIDProductDetailAsync(string id);
        Task<GetByIDProductDetailDto> GetByProductIDProductDetailAsync(string id);
    }
}