using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HBCase.Model.Entities
{
    public abstract class EntityBase : IEntity<string>
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        [BsonElement(Order = 0)]
        public string Id { get; set; }
    }
}