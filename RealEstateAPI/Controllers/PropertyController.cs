using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Core;
using RealEstate.Core.Entities;
using RealEstate.Core.Specifications;
using RealEstateAPI.DTOs;
using RealEstateAPI.Errors;
namespace RealEstateAPI.Controllers;
public class PropertyController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PropertyController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    // Get all properties
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<PropertyCardDTO>>> GetAllProperties()
    {
        var spec = new PropertySpecifications();
        var properties = await _unitOfWork.Repository<Property>().GetAllWithSpecAsync(spec);
        var mappedProperties = _mapper.Map<List<PropertyCardDTO>>(properties);
        return Ok(mappedProperties);
    }
    // Get property by Id
    [HttpGet("{id}")]
    public async Task<ActionResult<PropertyDTO>> GetPropertyById(int id)
    {
        var spec = new PropertySpecifications(id);
        var property = await _unitOfWork.Repository<Property>().GetEntityWithSpecAsync(spec);
        if (property == null) return NotFound(new ApiResponse(404));
        var mappedProperty = _mapper.Map<PropertyDTO>(property);
        return Ok(mappedProperty);
    }
    // Add property
    [HttpPost]
    public async Task<ActionResult> AddProperty(AddPropertyDTO propertyDTO)
    {
        var property = _mapper.Map<Property>(propertyDTO);
        await _unitOfWork.Repository<Property>().AddAsync(property);
        var result = await _unitOfWork.CompleteAsync();
        if (result > 0)
        {
            return NoContent();
        }
        return BadRequest(new ApiResponse(400, "Failed to add property"));
    }
    // Update property
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProperty(int id, AddPropertyDTO propertyDTO)
    {
        var property = await _unitOfWork.Repository<Property>().GetByIdAsync(id);
        if (property == null) return NotFound(new ApiResponse(404));
        _mapper.Map(propertyDTO, property);
        _unitOfWork.Repository<Property>().Update(property);
        var result = await _unitOfWork.CompleteAsync();
        if (result > 0)
        {
            return NoContent();
        }
        return BadRequest(new ApiResponse(400, "Failed to update property"));
    }

    // Delete property
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProperty(int id)
    {
        var property = await _unitOfWork.Repository<Property>().GetByIdAsync(id);
        if (property == null) return NotFound(new ApiResponse(404));
        _unitOfWork.Repository<Property>().Delete(property);
        var result = await _unitOfWork.CompleteAsync();
        if (result > 0)
        {
            return NoContent();
        }
        return BadRequest(new ApiResponse(400, "Failed to delete property"));
    }
 
}

