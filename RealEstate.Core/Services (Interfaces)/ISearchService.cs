using RealEstate.Core.Entities;


namespace RealEstate.Core.Services__Interfaces_;

public interface ISearchService
{
    Task<(List<Project>, List<Property>)> SearchAsync(int? locationId, int? projectTypeId, int? propertyTypeId, int? developerId);
}
