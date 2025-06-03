using MultiShop.DtoLayer.CatalogDtos.ProductDetailsDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDetailDto>("ProductDetails", createProductDetailDto);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _httpClient.DeleteAsync($"ProductDetails/{id}");
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var responseMessage = await _httpClient.GetAsync("ProductDetails");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDetailDto>>(jsonData);
            return values;
        }

        public async Task<GetByIDProductDetailDto> GetByIDProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"ProductDetails/{id}");
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIDProductDetailDto>();
            return values;
            //return await _httpClient.GetFromJsonAsync<GetByIDProductDetailDto>($"/ProductDetails/{id}");
        }

        public async Task<GetByIDProductDetailDto> GetByProductIDProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"ProductDetails/GetProductDetailByProductId/{id}");
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIDProductDetailDto>();
            return values;
        }

        public async Task UpdateProductDetailAsync(GetByIDProductDetailDto updateProductDetailDto)
        {
            await _httpClient.PutAsJsonAsync<GetByIDProductDetailDto>("ProductDetails", updateProductDetailDto);
        }
    }
}
