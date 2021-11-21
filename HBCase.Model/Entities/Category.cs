using MongoDB.Bson;

namespace HBCase.Model.Entities
{
    public class Category : EntityBase
    {

        public Category()
        {

        }

        public Category(string name, string description)
        {
            Id = ObjectId.GenerateNewId().ToString();
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}