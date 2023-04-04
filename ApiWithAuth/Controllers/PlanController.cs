using ApiWithAuth.Entity;
using ApiWithAuth.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ApiWithAuth.Controllers;
using Microsoft.AspNetCore.Mvc;



[Authorize]
[ApiController]
[Route("[controller]")]
public class PlanController: ControllerBase
{    
    private readonly UserManager<AppUser> _userManager;
    private readonly UsersContext _context;
    private readonly TokenService _tokenService;

    public PlanController(UserManager<AppUser> userManager, UsersContext context, TokenService tokenService)
    {
        _userManager = userManager;
        _context = context;
        _tokenService = tokenService;
    }


    [HttpGet]
    [Route("{email}")]
    public async Task<IResult> GetPlan(string email )
    {
        //Обработку бд запихать нада
        AppPlan plan = new AppPlan();
        plan.Id = 1111;
        plan.Creater = "11111";
        plan.Name = "1111";
       /* var que = new AppQuest{Links = {"a","b"}};
        que.Links.Add("123");
        que.Id = 15;
        que.Parent = plan.Name;
        plan.Quests.Add(que);*/
        return Results.Json(plan);
    }



    [HttpPost]
    [Route("Create")]
    public async Task<IResult> CreatePlane(CreatePlanRequest request)
    {
        
        return Results.Ok();
    }
    
}



