using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiWithAuth.Entity;

public class AppPlan
{
    
    public string? Name { get; set; }
    [Key]
    public int? Id { get; set; }
    public int AppUserId{ get; set; }
    public bool done { get; set; } = false;
    public IList<AppQuest> Quests { get; set; } = new List<AppQuest>();
    public AppUser AppUser{ get; set; }
}