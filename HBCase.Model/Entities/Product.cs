using MongoDB.Bson;

namespace HBCase.Model.Entities
{
    public class Product : EntityBase
    {

        public Product(string name, string description, string categoryId, decimal price, string currency)
        {
            Id = ObjectId.GenerateNewId().ToString();
            Name = name;
            Description = description;
            CategoryId = categoryId;
            Price = price;
            Currency = currency;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}