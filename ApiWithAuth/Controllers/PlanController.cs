using ApiWithAuth.Entity;
using Microsoft.AspNetCore.Authorization;

using Microsoft.EntityFrameworkCore;

namespace ApiWithAuth.Controllers;
using Microsoft.AspNetCore.Mvc;



[Authorize]
[ApiController]
[Route("/[controller]")]
public class PlanController: ControllerBase
{    

    private readonly UsersContext _context;


    public PlanController( UsersContext context)
    {
        _context = context;
    }


    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreatePlanAsync(AppPlan request,string email)
    {
        var usid= await _context.Users.FirstOrDefaultAsync(x => x.Email==email);
        request.AppUserId = usid.Id;
        await _context.AppPlans.AddAsync(request);
        await _context.SaveChangesAsync();
        return Ok();
        
    }



    [HttpGet]
    [Route("GetUserPlans{email}")]
    public async Task<IActionResult> GetUsersPlansAsync(string email)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);  
        }

        var userid = await _context.Users.FirstOrDefaultAsync( x => x.Email==email);
        var result = await _context.AppPlans.Include(x => x.Quests).Where(x => x.AppUserId == userid.Id).ToArrayAsync();
        return Ok(result);
    }


    [HttpPut]
    [Route("PutUserPlan/{id}")]
    public async Task<IActionResult> UpdatePlanAsync(AppPlan request, long id)
    {
        var result = await _context.AppPlans.Include(x => x.Quests).FirstOrDefaultAsync(x => x.Id == id);
        if (result==null)
        {
            return BadRequest(NotFound());  
        }

        _context.AppPlans.Update(request);
        await _context.SaveChangesAsync();
        return (Ok(result));
    }

    [HttpDelete]
    [Route("DeleteUserPlans{id}")]
    public async Task<IActionResult> RemovePlanAsync(long id)
    {
        var result = await _context.AppPlans.Include(x => x.Quests).FirstOrDefaultAsync(x => x.Id == id);
        _context.Remove(result);
        await _context.SaveChangesAsync();
        return Ok();
    }
}



