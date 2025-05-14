using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
        Task CreateProductImagesAsync(CreateProductImageDto createProductImagesDto);
        Task UpdateProductImagesAsync(UpdateProductImageDto updateProductImagesDto);
        Task DeleteProductImagesAsync(string id);
        Task<GetByIDProductImageDto> GetByIDProductImagesAsync(string id);

        Task<List<GetByIDProductImageDto>> GetByProductIDProdutsImageListAsync(string id);
    }
}
