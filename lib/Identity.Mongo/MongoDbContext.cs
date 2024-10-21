using MongoDB.Driver;

namespace Identity.Mongo;

public abstract class MongoDbContext
{
    protected IMongoDatabase Database { get; private set; } = null!;

    public void Initialize(IMongoDatabase db)
    {
        Database = db;
        ConfigureCollections();
    }

    protected abstract void ConfigureCollections();
}