using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace Back.Models;

public class MongoDbContext
{
    private readonly IMongoDatabase database;

    public MongoDbContext(IMongoClient client, IConfiguration configuration)
    {
        database = client.GetDatabase(configuration["MongoSettings:Database"]);
    }

    public IMongoDatabase Database => database;
    public GridFSBucket GridFsBucket => new GridFSBucket(database);
}
