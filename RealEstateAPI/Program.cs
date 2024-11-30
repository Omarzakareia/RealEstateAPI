using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate.Core.Entities.Identity;
using RealEstate.Repository.Data;
using RealEstate.Repository.Identity;
using RealEstateAPI.Extensions;
using RealEstateAPI.Middlewares;
using StackExchange.Redis;
namespace RealEstateAPI;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region Add services to the container
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerServices();

        builder.Services.AddDbContext<RealContext>(Options =>
        {
            Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        builder.Services.AddSingleton<IConnectionMultiplexer>(Options =>
        {
            var Connection = builder.Configuration.GetConnectionString("RedisConnection");

            return ConnectionMultiplexer.Connect(Connection);
        });
        builder.Services.AddDbContext<AppIdentityDbContext>(Options =>
        {
            Options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
        });
        builder.Services.AddApplicationService();
        builder.Services.AddIdentityServices(builder.Configuration);
        //builder.Services.AddCors(Options =>
        //{
        //    Options.AddPolicy("MyPolicy", options =>
        //    {
        //        options.AllowAnyHeader();
        //        options.AllowAnyMethod();
        //        options.WithOrigins(builder.Configuration["FrontBaseUrl"]);
        //    });
        //});
        #endregion

        var app = builder.Build();

        #region Update-Database
        using var Scope = app.Services.CreateScope();
        // Group of Services LifeTime Scooped
        var Services = Scope.ServiceProvider;
        // Services it self
        var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();
        try
        {
            var dbContext = Services.GetRequiredService<RealContext>();
            // Ask CLR For Creating Object From DbContext Explicitly
            await dbContext.Database.MigrateAsync(); //update-database

            var IdentityDbContext = Services.GetRequiredService<AppIdentityDbContext>();
            await IdentityDbContext.Database.MigrateAsync(); //update-database
            var UserManager = Services.GetRequiredService<UserManager<AppUser>>();

            await AppIdentityDbContextSeed.SeedUserAsync(UserManager);
            await RealContextSeed.SeedProjectTypes(dbContext);
            await RealContextSeed.SeedPropertyTypes(dbContext);


        }
        catch (Exception ex)
        {
            var Logger = LoggerFactory.CreateLogger<Program>();
            Logger.LogError(ex, "An Error Occured During Applying The Migration");
        }


        #endregion

        #region Configure the HTTP request pipeline.
        app.UseMiddleware<ExceptionMiddleWare>();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerMiddleWares();
        }
        app.UseStatusCodePagesWithReExecute("/errors/{0}");
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCors("MyPolicy");
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        #endregion

        app.Run();
    }
}
