using ApiWithAuth.DTOs;
using ApiWithAuth.Entity;

namespace ApiWithAuth.Interfaces;

public interface IPlanService
{
    Task<List<AppPlan>> GetAllPlansAsync();
    Task<List<AppPlan>> GetAllPlansThisUserAsync(string AppPlanEmail);
    Task <AppPlan?> GetPlanByIdAsync(int planId);
    Task CreatePlanAsync(AppPlan item, string email);
    Task RemovePlanAsync(int planId);
    Task<AppPlan> UpdatePlanAsync(AppPlan item, int planId);
    

}