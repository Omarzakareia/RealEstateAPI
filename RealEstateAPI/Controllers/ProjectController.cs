using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Core;
using RealEstate.Core.Entities;
using RealEstate.Core.Specifications;
using RealEstateAPI.DTOs;
using RealEstateAPI.Errors;
namespace RealEstateAPI.Controllers;
public class ProjectController : ApiBaseController
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public ProjectController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    //[CachedAttribute(300)]
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProjectCardDTO>>> GetAllProjects()
    {
        var spec = new ProjectSpecifications();
        var projects = await _unitOfWork.Repository<Project>().GetAllWithSpecAsync(spec);
        var mappedProjects = _mapper.Map<List<ProjectCardDTO>>(projects);
        return Ok(mappedProjects);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectDTO>> GetProjectById(int id)
    {
        var Spec = new ProjectSpecifications(id);
        var project = await _unitOfWork.Repository<Project>().GetEntityWithSpecAsync(Spec);
        if (project == null) return NotFound(new ApiResponse(404));
        var MappedProject = _mapper.Map<ProjectDTO>(project);
        return Ok(MappedProject);
    }

    [HttpPost]
    public async Task<ActionResult> CreateProject(AddProjectDTO projectDTO)
    {
        try
        {
            var project = _mapper.Map<AddProjectDTO, Project>(projectDTO);
            await _unitOfWork.Repository<Project>().AddAsync(project);
            var result = await _unitOfWork.CompleteAsync();
            if (result > 0) return NoContent();
            return BadRequest(new ApiResponse(400, "Failed to create project"));
        }
        catch (Exception ex)
        {
            // Log the exception
            return StatusCode(500, new ApiResponse(500, "Internal server error: " + ex.Message));
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Project>> DeleteProject(int id)
    {
        try
        {
            var Spec = new ProjectSpecifications(id);
            var project = await _unitOfWork.Repository<Project>().GetEntityWithSpecAsync(Spec);
            if (project == null) return NotFound(new ApiResponse(404));

            _unitOfWork.Repository<Project>().Delete(project);
            var result = await _unitOfWork.CompleteAsync();
            if (result > 0)
            {
                return NoContent();
            }
            return BadRequest(new ApiResponse(400, "Failed to delete project"));
        }
        catch
        {
            return BadRequest(new ApiResponse(400, "Failed to Delete project"));
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProject(int id, AddProjectDTO updateProjectDTO)
    {
        try
        {
            var Spec = new ProjectSpecifications(id);
            var project = await _unitOfWork.Repository<Project>().GetEntityWithSpecAsync(Spec);
            _mapper.Map(updateProjectDTO, project);
            _unitOfWork.Repository<Project>().Update(project);
            var result = await _unitOfWork.CompleteAsync();
            if (result > 0)
            {
                return NoContent();
            }
            return BadRequest(new ApiResponse(400, "Failed to Update project"));
        }
        catch
        {
            return BadRequest(new ApiResponse(500, "Internal Server Error"));
        }
    }

}
