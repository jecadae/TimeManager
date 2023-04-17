using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiWithAuth.Entity;

public class AppPlan
{
    
    public string? Name { get; set; }
    [Key]
    public long? Id { get; set; }
    [JsonIgnore]
    public long  AppUserId{ get; set; }
    public bool done { get; set; } = false;
    public IList<AppQuest> Quests { get; set; } = new List<AppQuest>();

    public void Update(AppPlan appPlan)
    {
        this.done = appPlan.done;
        this.Name = appPlan.Name;
        this.Quests = appPlan.Quests;
        
    }
}