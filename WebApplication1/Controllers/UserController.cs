using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entity;
namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly TokenService _tokenService;
   
   [Route("login")]
   [HttpPost]
   public IActionResult Login([FromBody] RequestLogin request)
   {
       if (!ModelState.IsValid)
       {
           return BadRequest(ModelState);
       }
       User testuser = new User()
       {
           Id = Guid.NewGuid().ToString(),
           Email ="user@mail.com",
           FirstName = "1",
           LastName ="2",
           Patronymic = "3",
           PasswordHash = "123123143423434322433211331424521452143",
       };
       var accessToken =  _tokenService.CreateToken(testuser);
       return Ok(new AuthResponce
       {
           Email = "user@mail.com",
           Token = accessToken,
       });
   }
   


}