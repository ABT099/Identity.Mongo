using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MockApp;

public class TestModel
{
    [BsonId]
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    public required string Name { get; set; }
}