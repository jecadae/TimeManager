namespace ApiWithAuth.Domain.Models;

public class AppPlan
{
    
    public string? Name { get; set; }
    public int? Id { get; set; }
    public int AppUserId{ get; set; }
    public bool IsReady { get; set; } 
    public IList<AppQuest> Quests { get; set; } = new List<AppQuest>();
    public AppUser AppUser{ get;}
}