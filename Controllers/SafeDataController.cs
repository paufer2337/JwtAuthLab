using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;




namespace JwtAuthLab.Controllers;


[ApiController]
[Route("api/[controller]")]
[Authorize]


public class SafeDataController : ControllerBase
{
    
    [HttpGet]
    public IActionResult GetSecureData()
    {
        var userName = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value;

        return Ok(new
        {
            Message = $"Grattis {userName}, du har nått en skyddad endpoint!"
        });
    }

}