using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class ProductImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductImageID { get; set; }
        public string ImageUrl { get; set; }
        public string ProductID { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
