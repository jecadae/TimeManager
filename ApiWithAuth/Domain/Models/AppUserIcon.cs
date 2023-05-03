using System.ComponentModel.DataAnnotations;

namespace ApiWithAuth.Entity;

public class AppUserIcon
{
    public int? Id { get; set; }
    public byte[] ImageArray { get; set; }
    public int? AppUserId { get; set; }
    public AppUser? AppUser{ get; set; }

}