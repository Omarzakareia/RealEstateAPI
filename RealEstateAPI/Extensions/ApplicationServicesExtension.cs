using Microsoft.AspNetCore.Mvc;
using RealEstate.Core;
using RealEstate.Core.Services;
using RealEstate.Core.Services__Interfaces_;
using RealEstate.Repository;
using RealEstate.Service;
using RealEstate.Services;
using RealEstateAPI.Errors;
using RealEstateAPI.Helpers;
namespace RealEstateAPI.Extensions;
public static class ApplicationServicesExtension
{
    public static IServiceCollection AddApplicationService(this IServiceCollection Services)
    {
        Services.AddSingleton<IResponseCacheService, ResponseCacheService>();
        Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        Services.AddScoped(typeof(ISearchService), typeof(SearchService));

        Services.AddAutoMapper(typeof(MappingProfiles));
        Services.Configure<ApiBehaviorOptions>(Options =>
        {
            Options.InvalidModelStateResponseFactory = (actionContext) =>
            {
                // ModelState => Dic[KeyValuePair]
                //Key => Name of parameter
                // Value => Error
                var errors = actionContext.ModelState.Where(p => p.Value.Errors.Count() > 0)
                                                                                 .SelectMany(P => P.Value.Errors)
                                                                                 .Select(E => E.ErrorMessage)
                                                                                 .ToArray();
                var ValidtionErrorResponse = new ApiValidationErrorResponse()
                {
                    Errors = errors
                };
                return new BadRequestObjectResult(ValidtionErrorResponse);
            };
        });
        return Services;
    }
}
