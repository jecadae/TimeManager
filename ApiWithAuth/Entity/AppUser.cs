using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace ApiWithAuth.Entity;

public class AppUser: IdentityUser
{
    public string FirstName { get; set; }
    public string LastName{get;set;}
    public string Patronymic{get;set;}
    [JsonIgnore] 
    public List<AppPlan>? UserPlans { get; set; } = new List<AppPlan>();
}