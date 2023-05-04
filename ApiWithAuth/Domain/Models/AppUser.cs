using Microsoft.AspNetCore.Identity;

namespace ApiWithAuth.Domain.Models;


public class AppUser: IdentityUser<int>
{
    
    public string? FirstName { get; set; }
    public string? LastName{get;set;}
    public string? Patronymic{get;set;}
    public int? AppUserIconsId{get;set;}
    public List<AppPlan>? UserPlans { get; set; } = new List<AppPlan>();
    public AppUserIcon? AppUserIcon { get; set; }
    
}