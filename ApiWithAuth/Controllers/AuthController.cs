using ApiWithAuth.DTOs;
using ApiWithAuth.Entity;
using ApiWithAuth.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithAuth.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public AuthController(UserManager<AppUser> userManager,IUserService userService,IMapper mapper )
    {
        _userManager = userManager;
        _userService = userService;
        _mapper = mapper;
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
            new AppUser { UserName = request.Email, Email = request.Email,
                FirstName = request.FirstName,LastName = request.LastName,Patronymic = request.Patronymic}, request.Password
        );
        if (result.Succeeded)
        {
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
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await _userService.LoginAsync(request));
    }
    
    [HttpPost]
    [Route("RefreshPass")]
    public async Task<ActionResult<AuthResponse>> RefreshPass(RefreshRequest request)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState);

        var accessToken =await _userService.PasswordUpdateAsync(request);
        return Ok(new AuthResponse
        {
            Email = request.Email,
            Token = accessToken,
        });
    }

    [HttpPost]
    [Route("rename")]
    [Authorize]
    public async Task<IActionResult> Rename(RenameRequest request)
    {
        await _userService.RenameUserAsync(request);
        return Ok();
    }

    [HttpPost]
    [Route("ForgotPass")]
    public async Task<ActionResult<AuthResponse>> ForgotPass(string email)
    {
        await _userService.ForgotPasswordAsync(email);
        return Ok();
    }
    
    [HttpGet]
    [Route("GetAllUsers")]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        return Ok(_mapper.Map<List<AppUserDto>>(await _userService.GetAllUsers()));
    }
    
    [HttpGet]
    [Route("GetUserByEmail{email}")]
    [Authorize]
    public async Task<IActionResult> GetUser(string email)
    {
        return Ok(_mapper.Map<AppUserDto>(await _userService.GetUserByEmail(email)));
    }
    

}