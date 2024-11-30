using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Core;
using RealEstate.Core.DTOs;
using RealEstate.Core.Entities;
using RealEstate.Core.Specifications;
using RealEstateAPI.Errors;
namespace RealEstateAPI.Controllers;
public class DeveloperController : ApiBaseController
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public DeveloperController(IMapper mapper , IUnitOfWork unitOfWork)
    {
        this._mapper = mapper;
        this._unitOfWork = unitOfWork;
    }
    // Get All Developers
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<DeveloperCardDTO>>> GetAllDevelopers()
    {
        var Spec = new DeveloperSpecification();
        var developers = await _unitOfWork.Repository<Developer>().GetAllWithSpecAsync(Spec);
        var mappedDevelopers = _mapper.Map<List<DeveloperCardDTO>>(developers);
        return Ok(mappedDevelopers);
    }
    // Get Developer By Id
    [HttpGet("{id}")]
    public async Task<ActionResult<DeveloperDTO>> GetDeveloperById(int id)
    {
        var Spec = new DeveloperSpecification(id);
        var developer = await _unitOfWork.Repository<Developer>().GetEntityWithSpecAsync(Spec);
        var mappedDeveloper = _mapper.Map<DeveloperDTO>(developer);
        return Ok(mappedDeveloper);
    }
    // Add Developer
    [HttpPost]
    public async Task<ActionResult> AddDeveloper([FromBody] AddDeveloperDTO developerDTO)
    {
        try
        {
            var mappedDeveloper = _mapper.Map<AddDeveloperDTO, Developer>(developerDTO);
            await _unitOfWork.Repository<Developer>().AddAsync(mappedDeveloper);
            var result = await _unitOfWork.CompleteAsync();
            if (result > 0)
                return NoContent();
            return BadRequest(new ApiResponse(400, "Failed to Create project"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ApiResponse(500, "Internal server error: " + ex.Message));
        }
    }
    // Update Developer
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateDeveloper(int id, [FromBody] AddDeveloperDTO developerDTO)
    {
        var Spec = new DeveloperSpecification(id);
        var developer = await _unitOfWork.Repository<Developer>().GetEntityWithSpecAsync(Spec);
        _mapper.Map(developerDTO, developer);
        _unitOfWork.Repository<Developer>().Update(developer);
        var result = await _unitOfWork.CompleteAsync();
        if (result > 0)
            return NoContent();
        return BadRequest(new ApiResponse(400, "Failed to Update Developer"));
    }
    // Delete Developer
    [HttpDelete("{id}")]
    public async Task<ActionResult<Developer>> DeleteDeveloper(int id)
    {
        var Spec = new DeveloperSpecification(id);
        var developer = await _unitOfWork.Repository<Developer>().GetEntityWithSpecAsync(Spec);
        _unitOfWork.Repository<Developer>().Delete(developer);
        var result = await _unitOfWork.CompleteAsync();
        if (result > 0)
            return NoContent();
        return BadRequest(new ApiResponse(400, "Failed to Delete Developer"));
    }
}
