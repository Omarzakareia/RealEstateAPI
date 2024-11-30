using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Core.Services__Interfaces_;
using RealEstateAPI.DTOs;
using RealEstateAPI.Errors;

namespace RealEstateAPI.Controllers;

public class SearchController : ApiBaseController
{
    private readonly ISearchService _searchService;
    private readonly IMapper _mapper;

    public SearchController(ISearchService searchService, IMapper mapper)
    {
        _searchService = searchService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult> Search(
        [FromQuery] int? locationId,
        [FromQuery] int? projectTypeId,
        [FromQuery] int? propertyTypeId,
        [FromQuery] int? developerId)
    {
        var (projects, properties) = await _searchService.SearchAsync(locationId, projectTypeId, propertyTypeId, developerId);

        if ((projects == null || !projects.Any()) && (properties == null || !properties.Any()))
        {
            return NotFound(new ApiResponse(404));
        }
        return Ok(new
        {
            Projects = _mapper.Map<List<ProjectCardDTO>>(projects),
            Properties = _mapper.Map<List<PropertyCardDTO>>(properties)
        });
    }
}
