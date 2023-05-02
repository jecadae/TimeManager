﻿using ApiWithAuth.DTOs;
using ApiWithAuth.Entity;

namespace ApiWithAuth.Interfaces;

public interface IPlanService
{
    Task<List<AppPlan>> GetAllPlansAsync();
    Task<List<AppPlan>> GetAllPlansThisUserAsync(string AppPlanEmail);
    Task <AppPlan?> GetPlanByIdAsync(int planId);
    Task CreatePlanAsync(AppPlan item, string email);
    Task RemovePlanAsync(int AppPlanId);
    Task UpdatePlanAsync(AppPlan item, string email);
    

}