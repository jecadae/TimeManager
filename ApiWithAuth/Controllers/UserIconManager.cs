using ApiWithAuth.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWithAuth.Controllers;





[ApiController]
[Route("/[controller]")]
public class UserIconManager: ControllerBase
{
    private readonly UsersContext _context;


    public UserIconManager( UsersContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("AddUserIcon{email}")]
    public async Task<IActionResult> AddUserIconAsync(string email, IFormFile file)
    {
        var userid = await _context.Users.AsNoTracking().FirstOrDefaultAsync( x => x.Email==email);
        var fileStream = file.OpenReadStream();
        byte[] bytes = new byte[file.Length];
        fileStream.Read(bytes, 0, (int)file.Length);

        _context.AppUserIcons.Add(new AppUserIcon
        {
            ImageArray = bytes,
            AppUserId = userid.Id,
        });
    
        await _context.SaveChangesAsync();
        return Ok(bytes);
    }

    [HttpGet]
    [Route("GetUserIcon{email}")]
    public async Task<IActionResult> SetUserIconAsync(string email)
    {
        var userid = await _context.Users.AsNoTracking().FirstOrDefaultAsync( x => x.Email==email);
        var icon = await _context.AppUserIcons.FirstOrDefaultAsync(ic => ic.AppUserId== userid.Id);
        var stream = new MemoryStream(icon.ImageArray);
        IFormFile file = new FormFile(stream, 0, icon.ImageArray.Length, "name", "fileName");
        return Ok(file.ContentDisposition);
    }
    
    [HttpPut]
    [Route("PutUserIcon{email}")]
    public async Task<IActionResult> PutUserIconAsync(string email, IFormFile file)
    {
        var userid = await _context.Users.AsNoTracking().FirstOrDefaultAsync( x => x.Email==email);
        var fileStream = file.OpenReadStream();
        byte[] bytes = new byte[file.Length];
        fileStream.Read(bytes, 0, (int)file.Length);
        var updatedIcon = await _context.AppUserIcons.FirstOrDefaultAsync(ic => ic.AppUserId== userid.Id);
        updatedIcon.ImageArray = bytes;
        await _context.SaveChangesAsync();
        return Ok(file.ContentDisposition);
    }
}