using Microsoft.AspNetCore.Identity;

namespace RealEstate.Core.Entities.Identity;

public class AppUser : IdentityUser<int>
{
    public override int Id { get; set; }    
    public string DisplayName { get; set; }
}
