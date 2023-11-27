using Microsoft.AspNetCore.Identity;

namespace ASPNet.API.Repositories;

public interface ITokenRepository
{
    string CreateJWTToken(IdentityUser user, List<string> roles);
}