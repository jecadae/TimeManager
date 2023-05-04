namespace ApiWithAuth.Domain.Models;


public class AppQuest
{

    public int? Id { get; set; }
    public int AppPlanId { get; set; }
    public string? Discription{ get; set; }
    public DateTime DeadLine { get; set; }
    private bool IsPrivate { get; set; }
    public bool IsReady { get; set; }
    public AppPlan AppPlan{ get; set; }
    public List<string> Links { get; set; } = new List<string>();


}