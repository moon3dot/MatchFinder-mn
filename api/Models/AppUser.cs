namespace api.Models;

public record AppUser(
     [property: BsonId, BsonRepresentation(BsonType.ObjectId)] string? Id,
    string Email,
    byte[] PasswordHash,
    byte[] PasswordSalt
);