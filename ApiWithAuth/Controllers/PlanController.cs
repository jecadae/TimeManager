using ApiWithAuth.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ApiWithAuth.Controllers;
using Microsoft.AspNetCore.Mvc;



[Authorize]
[ApiController]
[Route("/Plan/[controller]")]
public class PlanController: ControllerBase
{    

    private readonly UsersContext _context;


    public PlanController( UsersContext context)
    {
        _context = context;
    }


    [HttpPost]
    [Route("Create")]
    public async Task<IResult> CreatePlan(AppPlan request )
    {
        
        
        var result = _context.AppPlans;
        await _context.SaveChangesAsync();
        return Results.Ok();
        
    }



    [HttpGet]
    [Route("Read")]
    public async Task<IResult> CreatePlane(CreatePlanRequest request)
    {
        
        return Results.Ok();
    }
    
}



