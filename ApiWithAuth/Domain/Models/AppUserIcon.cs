namespace ApiWithAuth.Domain.Models;


public class AppUserIcon
{
    public int? Id { get; set; }
    public byte[] ImageArray { get; set; }
    public int? AppUserId { get; set; }
    public AppUser? AppUser{ get; set; }

}