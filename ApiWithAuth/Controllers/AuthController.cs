using ApiWithAuth.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWithAuth.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly UsersContext _context;
    private readonly TokenService _tokenService;

    public AuthController(UserManager<AppUser> userManager, UsersContext context, TokenService tokenService)
    {
        _userManager = userManager;
        _context = context;
        _tokenService = tokenService;
    }
    
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegistrationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);  
        }

        var result = await _userManager.CreateAsync(
            new AppUser { UserName = request.Email, Email = request.Email,FirstName = request.FirstName,LastName = request.LastName,Patronymic = request.Patronymic},
            request.Password
        );

        if (result.Succeeded)
        {
            request.Password = "";
            return Ok();
        }
        
        foreach (var error in result.Errors) { 
            ModelState.AddModelError(error.Code, error.Description); 
        }
        return BadRequest(ModelState);
    }
    
    [HttpPost]
    [Route("login")]
    
    public async Task<IActionResult> Authenticate(AuthRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var managedUser = await _userManager.FindByEmailAsync(request.Email);
        
        if (managedUser == null)
        {
            return BadRequest("Bad credentials");
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);

        if (!isPasswordValid)
        {
            return BadRequest("Bad credentials");
        }
        
        var userInDb = _context.Users.FirstOrDefault(u => u.Email == request.Email);
        if (userInDb is null)
            return Unauthorized();
        
        var accessToken = _tokenService.CreateToken(userInDb);
        await _context.SaveChangesAsync();
        Console.WriteLine($"{userInDb.Email},{accessToken}");
        var Auth = new AuthResponse
        {
            Email = userInDb.Email,
            Token = accessToken,
        };
        return Ok(Auth);
    }
    
    [HttpPost]
    [Route("RefreshPass")]
    public async Task<ActionResult<AuthResponse>> RefreshPass([FromBody] RefreshRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);  
        }
        
        var managedUser = await _userManager.FindByEmailAsync(request.Email);
        
        if (managedUser == null)
        {
            return BadRequest("Bad credentials");
        }
        
        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);
        
        if (!isPasswordValid)
        {
            return BadRequest("Bad credentials");
        }

        var result = await _userManager.ChangePasswordAsync(managedUser,request.Password,request.NewPassword);
        
        var userInDb = _context.Users.FirstOrDefault(u => u.Email == request.Email);
        if (userInDb is null)
            return Unauthorized();
        
        var accessToken = _tokenService.CreateToken(userInDb);
        await _context.SaveChangesAsync();
     
        return Ok(new AuthResponse
        {
            Email = userInDb.Email,
            Token = accessToken,
        });
    }

    [HttpPost]
    [Route("rename")]
    [Authorize]
    public async Task<ActionResult<AuthResponse>> Rename(string email, string name,string famile, string patronymic)
    {
        var userInDb = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (userInDb is null)
        {
            return NotFound();
        }
        userInDb.FirstName = name;
        userInDb.Patronymic = patronymic;
        userInDb.LastName = famile;
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost]
    [Route("ForgotPass")]
    public async Task<ActionResult<AuthResponse>> ForgotPass(string email)
    {
        var userInDb = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        string resetToken = await _userManager.GeneratePasswordResetTokenAsync(userInDb);
       //var message = new 
        Console.WriteLine(resetToken);
        return Ok();
    }


}