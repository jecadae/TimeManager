using ApiWithAuth.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithAuth.Controllers;

[ApiController]
[Route("/[controller]")]
public class UserIconController: ControllerBase
{
    private readonly IAppUserIconService _appUserIconService;

    public UserIconController( IAppUserIconService appUserIconService)
    {
        _appUserIconService = appUserIconService;
    }
    
    [HttpPost]
    [Route("AddUserIcon{email}")]
    public async Task<IActionResult> AddUserIconAsync(string email, IFormFile file)
    {
        await _appUserIconService.AddArrayFromPicturesAsync(email, file);
        return Ok();
    }

    [HttpGet]
    [Route("GetUserIcon{email}")]
    public async Task<IActionResult> GetUserIconAsync(string email)
    {
        return Ok(await _appUserIconService.GetImageArrayAsync(email));
    }

    [HttpPut]
    [Route("PutUserIcon{email}")]
    public async Task<IActionResult> PutUserIconAsync(string email, IFormFile file)
    {
        return Ok(await _appUserIconService.UpdateUserImageArrayAsync(email,file));
    }
}