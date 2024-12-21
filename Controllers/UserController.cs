using asp_rest_model.Interface.Repositoy;
using asp_rest_model.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_rest_model.Controllers;

[ApiController]
[Route("/user")]
public class UserController(IUserRepository ur): Controller
{
    private readonly IUserRepository _ur = ur;
    
    [HttpGet]
    [ProducesResponseType(typeof(List<User>), 200)]
    public IActionResult GetAll()
    {
        var users = _ur.GetAll();
        return Ok(users);
    }
}