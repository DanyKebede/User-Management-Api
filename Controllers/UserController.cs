using Microsoft.AspNetCore.Mvc;
using WebApi.Application;
using WebApi.Contract;
using WebApi.Domain;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{
    private readonly IUser _user;

    public UserController(IUser user)
    {
        _user = user;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _user.GetAllUsers();
        return Ok(users);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] Guid id)
    {
        var user = await _user.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }
        
        return Ok(user);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] UserCreateRequest request)
    {
        var newUser = await _user.CreateUser(request.FirstName, request.LastName);
        
        return Ok(newUser);
    }
}