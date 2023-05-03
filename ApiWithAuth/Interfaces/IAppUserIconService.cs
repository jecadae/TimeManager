namespace ApiWithAuth.Interfaces;

public interface IAppUserIconService
{
    Task AddArrayFromPicturesAsync(string email,IFormFile file);
    Task<byte[]> GetImageArrayAsync(string email);
    Task<byte[]> UpdateUserImageArrayAsync(string email,IFormFile file );
}