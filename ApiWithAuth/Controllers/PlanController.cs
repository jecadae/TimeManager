using ApiWithAuth.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ApiWithAuth.Controllers;
using Microsoft.AspNetCore.Mvc;



[Authorize]
[ApiController]
[Route("[controller]")]
public class PlanController: ControllerBase
{    

    private readonly ApplicationDbContext _context;


    public PlanController( ApplicationDbContext context)
    {
        _context = context;
    }


    [HttpPost]
    [Route("CreatePlan")]
    public async Task<IResult> GetPlan(AppPlan request )
    {
        //Обработку бд запихать нада
       /* AppPlan plan = new AppPlan();
        plan.Id = 11111;
        plan.Creater = "111111";
        plan.Name = "11111";
        var que = new AppQuest{Links = {"a","b"}};
        que.Links.Add("123");
        que.Id = 15;
        que.Discription = "1231";
        que.Parent = plan.Id;
        plan.Quests.Add(que);*/
        foreach (var appQuest in request.Quests)
        {
            appQuest.Init(request.Id);
        }
        
        var result = _context.AppPlans.Add(request);
        await _context.SaveChangesAsync();
        return Results.Ok();
        
    }



    [HttpPost]
    [Route("C")]
    public async Task<IResult> CreatePlane(CreatePlanRequest request)
    {
        
        return Results.Ok();
    }
    
}



