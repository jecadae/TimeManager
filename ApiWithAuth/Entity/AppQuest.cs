namespace ApiWithAuth.Entity;

public class AppQuest   
{
    public int Id { get; set; } 
    public int Parent  { get; set; }
    public string Discription{ get; set; }
    public DateTime DeadLine { get; set; }
    private bool priv { get; set; } = false;
    public bool Status { get; set; } = false;
    public List<string> Links { get; set; } = new List<string>();
}