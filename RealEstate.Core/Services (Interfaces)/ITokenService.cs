using Microsoft.AspNetCore.Identity;
using RealEstate.Core.Entities.Identity;
namespace RealEstate.Core.Services;
public interface ITokenService
{
    Task<string> CreateTokenAsync(AppUser User , UserManager<AppUser> userManager);
}
