using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs;

public record RegisterDto(
     // Email
     [MaxLength(30), RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$", ErrorMessage = "This email format is not correct")]
     string Email,
     //password
     [DataType(DataType.Password), MinLength(7) , MaxLength(30)]
     string Password,
     //confirm Password
     [DataType(DataType.Password), MinLength(7) , MaxLength(30)]
     string ConfirmPassword
);

public record LoginDto(
     // Email
     [MaxLength(30), RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$", ErrorMessage = "This email format is not correct")]
     string Email,
     // Password
     [DataType(DataType.Password), MinLength(7) , MaxLength(30)]
     string Password
);

public record LoggedInDto(
     // Id make Api
     string Id,
     // Email user in mongoDB
     string Email,
     // Token make Api
     string Token
);
