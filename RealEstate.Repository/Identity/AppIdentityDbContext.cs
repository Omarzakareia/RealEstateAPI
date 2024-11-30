using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Entities.Identity;
namespace RealEstate.Repository.Identity;
public class AppIdentityDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
{
    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> Options) : base(Options)
    {
    }
}
