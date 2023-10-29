using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;
[ApiController] // Defines properties and methods for API controller.
[Route("[contellor]")] // ASP.NET Core controllers use the Routing middleware to match the URLs of incoming requests and map them to actions. Route templates:
// after use in BaseController in to ControllerBase
public class BaseApiController : ControllerBase
{

}
