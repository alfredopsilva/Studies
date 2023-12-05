using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

public class AccountController : BaseApiController
{
  private readonly DataContext _context;

  public AccountController(DataContext context)
  {
    _context = context;
  }

  [HttpPost("register")]
  public async Task<ActionResult<AppUser>> Register(RegisterDto register)
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
    return user; 
  }

  [HttpPost("login")]
  public async Task<ActionResult<AppUser>> Login(LoginDto login)
  {
    var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == login.Username);

    if(user == null) return Unauthorized("Invalid Credentials");
    using var hmac = new HMACSHA512(user.PasswordSalt);
    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));
    for(int i = 0; i < computedHash.Length; i++)
    {
      if(computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Credentials");
    }

    return user; 

  }
  private async Task<bool> UserExists(string username)
  {
    return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
  }
}
