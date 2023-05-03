using ApiWithAuth.Domain;
using ApiWithAuth.Entity;
using ApiWithAuth.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        _
    }

    [HttpGet]
    [Route("GetUserIcon{email}")]
    public async Task<IActionResult> GetUserIconAsync(string email)
    {

    }

    [HttpPut]
    [Route("PutUserIcon{email}")]
    public async Task<IActionResult> PutUserIconAsync(string email, IFormFile file)
    {
        
    }
}