using ly.jwt.Constants;
using ly.jwt.Services.Contracts;
using ly.jwt.Services.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ly.jwt.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IJwtAuthentication _jwtAuthentication;
    private readonly IUserService _userService;

    public UserController(IJwtAuthentication jwtAuthentication, IUserService userService)
    {
        _jwtAuthentication = jwtAuthentication;
        _userService = userService;
    }

    [HttpPost]
    public IActionResult Login([FromBody] UserDto userDto) 
    {
        try
        {
            var user = _userService.Get(userDto.Username, userDto.Password);

            if (user is not null)
            {
                return Ok(_jwtAuthentication.GetToken(user));
            }
            else
            {
                return NotFound("Usuario no encontrado");
            }
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    [Authorize(Roles = ("Admin"))]
    public IActionResult GetAll()
    {
        try
        {
            return Ok(UserConstant.GetUsers());
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
