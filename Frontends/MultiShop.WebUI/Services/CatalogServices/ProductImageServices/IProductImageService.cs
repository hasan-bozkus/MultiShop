using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImagesDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImagesDto);
        Task DeleteProductImageAsync(string id);
        Task<UpdateProductImageDto> GetByIDProductImageAsync(string id);

        Task<List<GetByIDProductImageDto>> GetByProductIDProdutsImageListAsync(string id);
    }
}