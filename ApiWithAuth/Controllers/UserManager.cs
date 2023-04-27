using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithAuth.Controllers;





[ApiController]
[Route("/[controller]")]
public class UserManager: ControllerBase
{
    private readonly UsersContext _context;


    public UserManager( UsersContext context)
    {
        _context = context;
    }

    [HttpPost]
<<<<<<< HEAD
    [Route("CheckServer")]
    public async Task<IActionResult> CheckServer()
    {
=======
    [Route("Create")]
    public async Task<IActionResult> CreatePlanAsync()
    {

>>>>>>> bf90d5c1cb2f368eb924a6d85715fb78a4999b1d
        return Ok();
    }
     
    
    /// <summary>
    /// получить список друзьяшек
    /// добавить и удалить друзьяшку из списка
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("CheckServer")]
    public async Task<IActionResult> C()
    {
        return Ok();
    }
    

}