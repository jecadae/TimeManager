namespace ApiWithAuth.Entity;

public class AppPlan
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string  Creater{ get; set; }
    public bool done { get; set; } = false;
   public ICollection<AppQuest> Quests { get; set; } = new List<AppQuest>();

}