using ApiWithAuth.DTOs;
using ApiWithAuth.Entity;
using ApiWithAuth.Interfaces;
using ApiWithAuth.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithAuth.Controllers;

[Authorize]
[ApiController]
[Route("/[controller]")]
public class PlanController : ControllerBase
{
    private readonly IPlanService _planService;
    private readonly IMapper _mapper;
    
    public PlanController(IPlanService planService, IMapper mapper)
    {
        _planService = planService;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("GetPlansThisUser/{email}")]
    public async Task<IActionResult> GetUsersPlansAsync(string email)
    {
        return Ok(_mapper.Map<List<AppPlanDto>>(await _planService.GetAllPlansThisUserAsync(email)));
    }

    [HttpGet]
    [Route("GetAllUsersPlans")]
    public async Task<IActionResult> GetAllUsersPlansAsync()
    {
        return Ok( _mapper.Map<List<AppPlanDto>>(await _planService.GetAllPlansAsync()));
    }

    [HttpGet]
    [Route("GetPlanById/{planId}")]
    public async Task<IActionResult> GetUserPlanByIdAsync(int planId)
    {
        return Ok(_mapper.Map<AppPlanDto>(await _planService.GetPlanByIdAsync(planId)));
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreatePlanAsync(AppPlanDto request, string email)
    {
        await _planService.CreatePlanAsync(_mapper.Map<AppPlan>(request), email);
        return Ok();
    }

    [HttpPut]
    [Route("PutUserPlan")]
    public async Task<IActionResult> UpdatePlanAsync(AppPlanDto request)
    {
        await _planService.UpdatePlanAsync(_mapper.Map<AppPlan>(request));
        return Ok();
    }

    [HttpDelete]
    [Route("DeleteUserPlans/{id}")]
    public async Task<IActionResult> RemovePlanAsync(int id)
    {
        await _planService.RemovePlanAsync(id);
        return Ok();
    }
}