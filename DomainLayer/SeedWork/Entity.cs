using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DomainLayer.SeedWork
{
    public class Entity
    {
        [BsonId]
        public ObjectId EntityId { get; protected set; }
    }
}
