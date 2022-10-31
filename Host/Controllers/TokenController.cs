using App.Shared.Routes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Host.Controllers;

[Route(TokenEndpoints.Base)]
[ApiController]
public class TokenController : ControllerBase
{
	[HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok();
    }
}
