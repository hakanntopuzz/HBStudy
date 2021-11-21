namespace HBCase.Model.Results
{
    public class ProductResult
    {
        public ProductResult()
        {

        }

        public ProductResult(string id, string name, string description, string categoryId, decimal price, string currency)
        {
            Id = id;
            Name = name;
            Description = description;
            CategoryId = categoryId;
            Price = price;
            Currency = currency;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}