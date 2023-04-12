using ApiWithAuth.Migrations;

namespace ApiWithAuth.Entity;

public class AppQuest
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Parent { get; set; }
    public string Discription{ get; set; }
    public DateTime DeadLine { get; set; }
    private bool priv { get; set; } = false;
    public bool Status { get; set; } = false;
    public List<string> Links { get; set; } = new List<string>();
    public void Init(String parent)
    {
        this.Parent = parent;
    }
    
    
}