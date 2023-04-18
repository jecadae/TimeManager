using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithAuth.Controllers;




[Authorize]
[ApiController]
[Route("/[controller]")]
public class UserManager: ControllerBase
{
    private readonly UsersContext _context;


    public UserManager( UsersContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreatePlanAsync()
    {

        return Ok();
    }


}