using ApiWithAuth.Entity;
using ApiWithAuth.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithAuth.Controllers;

[Authorize]
[ApiController]
[Route("/[controller]")]
public class PlanController : ControllerBase
{
    private readonly IPlanService _planService;
    
    public PlanController(IPlanService planService)
    {
        _planService = planService;
    }

    [HttpGet]
    [Route("GetPlansThisUser{email}")]
    public async Task<IActionResult> GetUsersPlansAsync(string email)
    {
        return Ok(await _planService.GetAllPlansThisUserAsync(email));
    }

    [HttpGet]
    [Route("GetAllUsersPlans")]
    public async Task<IActionResult> GetAllUsersPlansAsync()
    {
        return Ok(await _planService.GetAllPlansAsync());
    }

    [HttpGet]
    [Route("GetPlanById{PlanId}")]
    public async Task<IActionResult> GetUserPlanByIdAsync(int planId)
    {
        return Ok(await _planService.GetPlanByIdAsync(planId));
    }

    [HttpPost]
    [Route("Create")]
    public IActionResult CreatePlanAsync(AppPlan request, string email)
    {
        return Ok(_planService.CreatePlanAsync(request, email));
    }

    [HttpPut]
    [Route("PutUserPlan/{id}")]
    public async Task<IActionResult> UpdatePlanAsync(AppPlan request, int id)
    {
        return Ok(await _planService.UpdatePlanAsync(request, id));
    }

    [HttpDelete]
    [Route("DeleteUserPlans{id}")]
    public IActionResult RemovePlanAsync(int id)
    {
        return Ok(_planService.RemovePlanAsync(id));
    }
}