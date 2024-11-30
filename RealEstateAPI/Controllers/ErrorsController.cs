using Microsoft.AspNetCore.Mvc;
using RealEstateAPI.Errors;
namespace RealEstateAPI.Controllers;

[Route("errors/{Code}")]
[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorsController : ControllerBase
{
    public ActionResult Error(int Code)
    {
        return NotFound(new ApiResponse(Code));
    }
}
