using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Identity.Mongo;

public static class DbBuilder
{
    public static void AddMongoDb<TDb>(
        this IServiceCollection services, 
        string connectionString,
        string databaseName) 
        where TDb : MongoDbContext
    {
        services.AddSingleton<IMongoClient>(_ => new MongoClient(connectionString));
        services.AddSingleton<IMongoDatabase>(sp =>
        {
            var mongoClient = sp.GetRequiredService<IMongoClient>();
            return mongoClient.GetDatabase(databaseName);
        });
        
        services.AddScoped<TDb>(sp =>
        {
            var db = sp.GetRequiredService<IMongoDatabase>();
            var context = ActivatorUtilities.CreateInstance<TDb>(sp);

            context.Initialize(db);
            return context;
        });
    }
}