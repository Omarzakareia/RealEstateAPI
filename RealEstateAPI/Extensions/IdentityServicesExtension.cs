using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using RealEstate.Core.Entities.Identity;
using RealEstate.Core.Services;
using RealEstate.Service;
using RealEstate.Repository.Identity;
namespace RealEstateAPI.Extensions;
public static class IdentityServicesExtension
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection Services, IConfiguration configuration)
    {
        Services.AddScoped<ITokenService, TokenService>();

        Services.AddIdentity<AppUser, IdentityRole<int>>()
            .AddEntityFrameworkStores<AppIdentityDbContext>();

        Services.AddAuthentication(Options =>
        {
            Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(Options =>
            {
                Options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
                };
            });
        return Services;
    }
}
