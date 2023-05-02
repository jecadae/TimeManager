namespace ApiWithAuth.DTOs;

public class AppPlanDto
{
        
    public string? Name { get; set; }
    public long? Id { get; set; }
    public string AppUserEmail { get; set; }
    public bool done { get; set; } = false;
    public IList<AppQuestDto> Quests { get; set; } = new List<AppQuestDto>();
}