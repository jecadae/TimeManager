using ApiWithAuth.Domain.Models;

namespace ApiWithAuth.Interfaces;

public interface IPlanService
{
    Task<List<AppPlan>> GetAllPlansAsync();
    Task<List<AppPlan>> GetAllPlansThisUserAsync(string email);
    Task <AppPlan?> GetPlanByIdAsync(int planId);
    Task CreatePlanAsync(AppPlan item, string email);
    Task RemovePlanAsync(int planId);
    Task UpdatePlanAsync(AppPlan item);
    

}