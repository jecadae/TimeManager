using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ApiWithAuth.Entity;

public class AppQuest
{
    [Key]
    [JsonIgnore]
    public long Id { get; set; }
    [ForeignKey("AppPlan")]
    [JsonIgnore]
    public long Parent { get; set; }
    public string Discription{ get; set; }
    public DateTime DeadLine { get; set; }
    private bool priv { get; set; } = false;
    public bool Status { get; set; } = false;
    
    
    public List<string> Links { get; set; } = new List<string>();


}