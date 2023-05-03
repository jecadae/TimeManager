namespace ApiWithAuth.DTOs;

public class AppQuestDto
{

    public int? Id { get; set; } = null;
    public string? Discription{ get; set; }
    public DateTime DeadLine { get; set; }
    private bool priv { get; set; }
    public bool Status { get; set; } 
    public List<string> Links { get; set; } = new List<string>();
}