using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Core;
using RealEstate.Core.Entities;
using RealEstate.Core.Specifications;
using RealEstateAPI.DTOs;
using RealEstateAPI.Errors;
namespace RealEstateAPI.Controllers;
public class CallRequestController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CallRequestController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    // Create a new call request for a property
    [HttpPost]
    public async Task<ActionResult> CreateCallRequest(int id, [FromBody] AddCallRequestDTO requestDto)
    {
        var callRequest = _mapper.Map<AddCallRequestDTO, CallRequest>(requestDto);
        await _unitOfWork.Repository<CallRequest>().AddAsync(callRequest);
        var result = await _unitOfWork.CompleteAsync();
        if (result > 0) return NoContent();
        return BadRequest(new ApiResponse(400, "Failed to add CallRequest"));
    }
    // Get all call requests for a property
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<CallRequestDTO>>> GetCallRequests()
    {
        var Spec = new CallRequestSpecifications();
        var requests = await _unitOfWork.Repository<CallRequest>().GetAllWithSpecAsync(Spec);
        var mappedRequests = _mapper.Map<List<CallRequestDTO>>(requests);
        return Ok(mappedRequests);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<CallRequestDTO>> GetCallRequestById(int id)
    {
        var Spec = new CallRequestSpecifications(id);
        var request = await _unitOfWork.Repository<CallRequest>().GetEntityWithSpecAsync(Spec);
        if (request == null) return NotFound(new ApiResponse(404));
        var mappedRequest = _mapper.Map<CallRequestDTO>(request);
        return Ok(mappedRequest);
    }
    // Delete a call request by ID
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCallRequest(int id)
    {
        var Spec = new CallRequestSpecifications(id);
        var callRequest = await _unitOfWork.Repository<CallRequest>().GetEntityWithSpecAsync(Spec);
        if (callRequest == null) return NotFound("Call request not found.");
        _unitOfWork.Repository<CallRequest>().Delete(callRequest);
        await _unitOfWork.CompleteAsync();
        return NoContent();
    }
}
