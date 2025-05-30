using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Back.Models;

public record PasswordResetDTO
{
    [BsonId]
    public ObjectId Id { get; set; }

    public int UserId { get; set; }

    public string Code { get; set; } = null!;

    public DateTime ExpiresAt { get; set; }
}
