using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
/// <summary>
/// controller for login and register 
/// </summary>
public class AccountController : BaseApiController
{
     #region  global varabel
     private readonly IAccountRepository _accountRepository;
     #endregion

     #region  constractor dependency injection
     public AccountController(IAccountRepository accountRepository)
     {
          _accountRepository = accountRepository;
     }
     #endregion

     [HttpPost("register")]
     public async Task<ActionResult<LoggedInDto>> Registe(RegisterDto userInput, CancellationToken cancellationToken)
     {
          // Check sync password and confirm password
          if (userInput.Password == userInput.ConfirmPassword)
               return BadRequest("Password is`n mach");

          // 
          LoggedInDto? loggedInDto = await _accountRepository.CreatAsync(userInput, cancellationToken);

          if (loggedInDto is null)
               return BadRequest("Email/Username is taken.");

          return loggedInDto;
     }
}
