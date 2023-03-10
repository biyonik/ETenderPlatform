using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ETenderPlatform.ProductApi.Entities;

public class Product
{
    [BsonId]
    // [BsonRepresentation(BsonType.ObjectId)]
    public Guid Id { get; set; }
    
    [BsonElement("Name")]
    public string Name { get; set; }
    
    public string Category { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}