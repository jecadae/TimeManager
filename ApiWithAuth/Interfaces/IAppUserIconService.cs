namespace ApiWithAuth.Interfaces;

public interface IAppUserIconService
{
    Task AddArrayFromPicturesAsync(IFormFile file,string email);
    Task<byte[]> GetImageArrayAsync(string email);
    Task<byte[]> UpdateUserImageArrayAsync(IFormFile file, string email);
}