using Back.Models;

using MongoDB.Driver;
using System.Security.Cryptography;

namespace Back.Services;

public class PasswordResetService : IPasswordResetService
{
    private readonly IMongoCollection<PasswordResetDTO> collection;

    public PasswordResetService(MongoDbContext context)
    {
        collection = context.Database.GetCollection<PasswordResetDTO>("PasswordResetCodes");

        var indexKeys = Builders<PasswordResetDTO>.IndexKeys.Ascending(x => x.ExpiresAt);
        var indexOptions = new CreateIndexOptions { ExpireAfter = TimeSpan.Zero };
        var indexModel = new CreateIndexModel<PasswordResetDTO>(indexKeys, indexOptions);
        collection.Indexes.CreateOne(indexModel);
    }

    public async Task<string> CreateResetCode(int userId)
    {
        string code = RandomNumberGenerator.GetInt32(100000, 1000000).ToString();

        var document = new PasswordResetDTO
        {
            UserId = userId,
            Code = code,
            ExpiresAt = DateTime.UtcNow.AddDays(1)
        };

        await collection.InsertOneAsync(document);
        return code;
    }

    public async Task<bool> VerifyResetCode(int userId, string code)
    {
        var filter = Builders<PasswordResetDTO>.Filter.And(
            Builders<PasswordResetDTO>.Filter.Eq(x => x.UserId, userId),
            Builders<PasswordResetDTO>.Filter.Eq(x => x.Code, code)
        );

        var result = await collection.Find(filter).FirstOrDefaultAsync();
        return result != null;
    }
}
