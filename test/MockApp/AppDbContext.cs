using Identity.Mongo;
using MongoDB.Driver;

namespace MockApp;

public class AppDbContext : MongoDbContext
{
    protected override void ConfigureCollections()
    {
        Collection = Database.GetCollection<TestModel>("tests");
    }

    public required IMongoCollection<TestModel> Collection { get; set; }
}