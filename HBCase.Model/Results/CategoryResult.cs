namespace HBCase.Model.Results
{
    public class CategoryResult
    {
        public CategoryResult(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}