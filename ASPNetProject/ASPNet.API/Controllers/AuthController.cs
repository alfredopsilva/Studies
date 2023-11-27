using ASPNet.API.Models.DTOs;
using ASPNet.API.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPNet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITokenRepository _tokenRepository;

    public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
    {
        _userManager = userManager;
        _tokenRepository = tokenRepository;
    }
    
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDto)
    {
        var identityUser = new IdentityUser
        {
            UserName = registerRequestDto.Username,
            Email = registerRequestDto.Username
        };

        var identityResult = await _userManager.CreateAsync(identityUser, registerRequestDto.Password);

        if (identityResult.Succeeded)
        {
            //Add Roles to this user. 
            if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
            {
                identityResult = await _userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                if (identityResult.Succeeded)
                {
                    return Ok("User was registered! Please Login!");
                }
            }
        }

        return BadRequest("Something Went Wrong. Check your data!");
    }
    
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDto)
    {
        var user = await _userManager.FindByEmailAsync(loginRequestDto.Username);

        if (user != null)
        {
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            if (isPasswordValid)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles != null)
                {
                    var  jwtToken = _tokenRepository.CreateJWTToken(user,roles.ToList());
                    var response = new LoginResponseDTO
                    {
                        JwtToken = jwtToken
                    };
                    return Ok(response);
                    
                }
            }
        }

        return BadRequest("Username or Password were incorrect.");
    }
    
}