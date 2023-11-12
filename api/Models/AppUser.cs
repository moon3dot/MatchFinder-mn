namespace api.Models;

// Model for save in data base
public record AppUser(
     [property : BsonId, BsonRepresentation(BsonType.ObjectId)]
     string? Id, // Aptional null 
     string Email,
     byte[] PasswordHash, // Arry
     byte[] PasswordSalt
);