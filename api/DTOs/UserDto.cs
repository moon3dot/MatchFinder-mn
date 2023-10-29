namespace api.DTOs;

public record UserDto(
     // Id make mongoDB
     string Id,
     // User email in mongoDB
     string Email
);
