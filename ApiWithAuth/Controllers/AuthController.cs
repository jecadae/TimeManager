using ApiWithAuth.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            new AppUser { UserName = request.Username, Email = request.Email,FirstName = request.FirstName,LastName = request.LastName,Patronymic = request.Patronymic},
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
    public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
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
     
        return Ok(new AuthResponse
        {
            Email = userInDb.Email,
            Token = accessToken,
        });
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
    
    
}