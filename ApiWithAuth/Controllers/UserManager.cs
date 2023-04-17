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
    [Route("CheckServer")]
    public async Task<IActionResult> CheckServer()
    {
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