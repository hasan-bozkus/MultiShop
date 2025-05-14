using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageServie : IProductImageService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductImage> _productImageCollection;

        public ProductImageServie(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImagesAsync(CreateProductImageDto createProductImagesDto)
        {
            var value = _mapper.Map<ProductImage>(createProductImagesDto);
            await _productImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImagesAsync(string id)
        {
            await _productImageCollection.DeleteOneAsync(x => x.ProductImageID == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
        {
            var values = await _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIDProductImageDto> GetByIDProductImagesAsync(string id)
        {
            var values = await _productImageCollection.Find(x => x.ProductImageID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIDProductImageDto>(values);
        }

        public async Task<List<GetByIDProductImageDto>> GetByProductIDProdutsImageListAsync(string id)
        {
            var values = await _productImageCollection.Find(x => x.ProductID == id).ToListAsync();
            return _mapper.Map<List<GetByIDProductImageDto>>(values);
        }

        public async Task UpdateProductImagesAsync(UpdateProductImageDto updateProductImagesDto)
        {
            var value = _mapper.Map<ProductImage>(updateProductImagesDto);
            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageID == updateProductImagesDto.ProductImageID, value);
        }
    }
}
