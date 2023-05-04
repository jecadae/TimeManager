namespace ApiWithAuth.DTOs;

public class AppPlanDto
{
        
    public string? Name { get; set; }
    public int? Id { get; set; }
    public bool Done { get; set; } 
    public IList<AppQuestDto> QuestsDto { get; set; } = new List<AppQuestDto>();
}