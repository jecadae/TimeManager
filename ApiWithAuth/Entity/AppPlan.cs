namespace ApiWithAuth.Entity;

public class AppPlan
{
    public string Name { get; set; }
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string  Creater{ get; set; }
    public bool done { get; set; } = false;
    public IList<AppQuest> Quests { get; set; } = new List<AppQuest>();
}