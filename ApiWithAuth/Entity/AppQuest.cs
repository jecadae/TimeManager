namespace ApiWithAuth.Entity;

public class AppQuest   
{
    public int Id { get; set; } 
    public String Parent  { get; set; }

    public DateTime DeadLine { get; set; }

    public bool Status { get; set; } = false;
    public ICollection<Link> Links { get; set; } = new List<Link>();
}