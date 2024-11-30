using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Core;
using RealEstate.Core.Entities;
using RealEstateAPI.DTOs;
using RealEstateAPI.Errors;
namespace RealEstateAPI.Controllers;
public class LocationController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public LocationController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    // Get all locations
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<LocationCardDTO>>> GetAllLocations()
    {
        var Spec = new LocationSpecification();
        var locations = await _unitOfWork.Repository<Location>().GetAllWithSpecAsync(Spec);
        var mappedLocations = _mapper.Map<List<LocationCardDTO>>(locations);
        return Ok(mappedLocations);
    }
    // Get location by Id
    [HttpGet("{id}")]
    public async Task<ActionResult<LocationDTO>> GetLocationById(int id)
    {
        var Spec = new LocationSpecification(id);
        var location = await _unitOfWork.Repository<Location>().GetEntityWithSpecAsync(Spec);
        if (location == null) return NotFound(new ApiResponse(404));
        var mappedLocation = _mapper.Map<LocationDTO>(location);
        return Ok(mappedLocation);
    }
    // Add Location
    [HttpPost]
    public async Task<ActionResult> AddLocation(AddLocationDTO locationDTO)
    {
        var location = _mapper.Map<Location>(locationDTO);
        await _unitOfWork.Repository<Location>().AddAsync(location);
        var result = await _unitOfWork.CompleteAsync();
        if (result > 0)
        {
            return NoContent();
        }
        return BadRequest(new ApiResponse(400, "Failed to add location"));
    }
    // Delete Location
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteLocation(int id)
    {
        var Spec = new LocationSpecification(id);
        var location = await _unitOfWork.Repository<Location>().GetEntityWithSpecAsync(Spec);
        if (location == null) return NotFound(new ApiResponse(404));
        _unitOfWork.Repository<Location>().Delete(location);
        var result = await _unitOfWork.CompleteAsync();
        if (result > 0)
        {
            return NoContent();
        }
        return BadRequest(new ApiResponse(400, "Failed to delete location"));
    }
    // Update Location
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateLocation(int id, AddLocationDTO locationDTO)
    {
        var Spec = new LocationSpecification(id);
        var location = await _unitOfWork.Repository<Location>().GetEntityWithSpecAsync(Spec);
        if (location == null) return NotFound(new ApiResponse(404));
        _mapper.Map(locationDTO, location);
        _unitOfWork.Repository<Location>().Update(location);
        var result = await _unitOfWork.CompleteAsync();
        if (result > 0)
        {
            return NoContent();
        }
        return BadRequest(new ApiResponse(400, "Failed to update location"));
    }
}
