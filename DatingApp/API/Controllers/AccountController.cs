using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

public class AccountController : BaseApiController
{
  private readonly DataContext _context;
  private readonly ITokenService _tokenService;

  public AccountController(DataContext context, ITokenService tokenService)
  {
    _context = context;
    _tokenService = tokenService;
  }

  [HttpPost("register")]
  public async Task<ActionResult<UserDto>> Register(RegisterDto register)
  {
    if (await UserExists(register.Username)) return BadRequest("Username is taken.");
    using var hmac = new HMACSHA512();
    var user = new AppUser
    {
      UserName = register.Username.ToLower(), 
      PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(register.Password)),
      PasswordSalt = hmac.Key
    };

    _context.Users.Add(user);
    await _context.SaveChangesAsync(); 
    
    return new UserDto
    {
      Username = user.UserName, 
      Token = _tokenService.CreateToken(user)
    }; 

  }

  [HttpPost("login")]
  public async Task<ActionResult<UserDto>> Login(LoginDto login)
  {
    var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == login.Username);

    if(user == null) return Unauthorized("Invalid Credentials");
    using var hmac = new HMACSHA512(user.PasswordSalt);
    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));
    for(int i = 0; i < computedHash.Length; i++)
    {
      if(computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Credentials");
    }

    return new UserDto
    {
      Username = user.UserName,
      Token = _tokenService.CreateToken(user)
    };

  }
  private async Task<bool> UserExists(string username)
  {
    return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
  }
}
