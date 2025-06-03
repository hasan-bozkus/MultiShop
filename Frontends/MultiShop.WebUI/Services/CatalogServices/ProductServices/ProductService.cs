using MultiShop.DtoLayer.CatalogDtos.ProductDto;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDto>("Products", createProductDto);

        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync($"Products/{id}");
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Products");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return values;
        }

        public async Task<ResultProductDto> GetByIDProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"Products/{id}");
            var values = await responseMessage.Content.ReadFromJsonAsync<ResultProductDto>();
            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryByCategoryIdAsync(string categoryId)
        {
            var responseMessage = await _httpClient.GetAsync($"Products/ProductListWithCategory/{categoryId}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetResultProductWithCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Products/ProductListWithCategory");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            return values;
        }

        public async Task UpdateProductAsync(ResultProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync<ResultProductDto>("Products", updateProductDto);
        }
    }
}
