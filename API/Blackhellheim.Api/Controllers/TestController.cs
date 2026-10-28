using Microsoft.AspNetCore.Mvc;

namespace Blackhellheim.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public Task<IActionResult> Test()
    {
        return "hola";
    }
}
