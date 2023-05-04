using ApiWithAuth.Domain;
using ApiWithAuth.Domain.Models;
using ApiWithAuth.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiWithAuth.Services;

public class AppUserIconService: IAppUserIconService
{
    private readonly UsersContext _context;

    public AppUserIconService( UsersContext context)
    {
        _context = context;
    }
    
    
    public async Task AddArrayFromPicturesAsync(string email,IFormFile file)
    {
        
        var userId = await _context.Users.AsNoTracking().FirstOrDefaultAsync( x => x.Email==email);
        if (userId == null)
            throw new BadHttpRequestException("Такой пользователь не был зарегестрирован",404);
        var fileStream = file.OpenReadStream();
        byte[] bytes = new byte[file.Length];
        fileStream.Read(bytes, 0, (int)file.Length);
        
        _context.AppUserIcons.Add(new AppUserIcon
        {
            ImageArray = bytes,
            AppUserId = userId.Id,
        });
        await _context.SaveChangesAsync();
    }

    public async Task<byte[]?> GetImageArrayAsync(string email)
    {
        var userId = await _context.Users.AsNoTracking().FirstOrDefaultAsync( x => x.Email==email);
        if (userId == null)
            throw new BadHttpRequestException("Такой пользователь не был зарегестрирован",404);
        var icon = await _context.AppUserIcons.FirstOrDefaultAsync(ic => ic.AppUserId== userId.Id);
        return (icon.ImageArray);
    }

    public async Task<byte[]> UpdateUserImageArrayAsync(string email,IFormFile file )
    {
        var userId = await _context.Users.AsNoTracking().FirstOrDefaultAsync( x => x.Email==email);
        if (userId == null)
            throw new BadHttpRequestException("Такой пользователь не был зарегестрирован",404);
        
        var fileStream = file.OpenReadStream();
        byte[] bytes = new byte[file.Length];
        fileStream.Read(bytes, 0, (int)file.Length);
        
        var updatedIcon = await _context.AppUserIcons.FirstOrDefaultAsync(ic => ic.AppUserId== userId.Id);
        updatedIcon.ImageArray = bytes;
        await _context.SaveChangesAsync();
        return (bytes);
    }
}
