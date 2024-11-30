using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateAPI.DTOs.RoleDTOs;
using RealEstateAPI.Errors;
using RealEstate.Core.Entities.Identity;
namespace RealEstateAPI.Controllers;

[Authorize(Roles = "Admin")] // Example of restricting access to Admin role
public class RoleController : ApiBaseController
{
    private readonly RoleManager<IdentityRole<int>> _roleManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public RoleController(RoleManager<IdentityRole<int>> roleManager,
        UserManager<AppUser> userManager, IMapper mapper)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _mapper = mapper;
    }

    // POST: api/Role
    [HttpPost]
    public async Task<ActionResult<RoleDTO>> CreateRole([FromBody] RoleDTO model)
    {
        if (ModelState.IsValid)
        {
            var role = new IdentityRole<int> { Name = model.RoleName };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                var mappedRole = _mapper.Map<IdentityRole<int>, RoleDTO>(role);
                return CreatedAtAction(nameof(GetRoles), new { id = role.Id }, mappedRole);
            }
            return NotFound(new ApiResponse(400));
        }
        return NotFound(new ApiResponse(400));
    }
    // GET: api/Role
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoleDTO>>> GetRoles()
    {
        var roles = await _roleManager.Roles.ToListAsync();
        if (roles == null || !roles.Any())
        {
            return NotFound(new ApiResponse(404, "No roles found"));
        }
        var mappedRoles = _mapper.Map<IEnumerable<IdentityRole<int>>, IEnumerable<GetAllRolesDTO>>(roles);
        return Ok(mappedRoles);
    }
    [HttpPost("{roleName}/users/add")]
    public async Task<ActionResult> AddUserToRole(string roleName, [FromBody] string userId)
    {
        // Find the role
        var role = await _roleManager.FindByNameAsync(roleName);
        if (role == null) return NotFound(new ApiResponse(404));

        // Find the user
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return NotFound(new ApiResponse(404));

        // Check if user already in role
        var isInRole = await _userManager.IsInRoleAsync(user, roleName);
        if (isInRole) return NotFound(new ApiResponse(400));

        // Add user to role
        var result = await _userManager.AddToRoleAsync(user, roleName);
        if (result.Succeeded)
            return Ok($"User '{user.UserName}' successfully added to role '{roleName}'.");
        else
            return NotFound(new ApiResponse(400));
    }


    [HttpPost("{roleName}/users/remove")]
    public async Task<ActionResult> RemoveUserFromRole(string roleName, [FromBody] string userName)
    {
        // Find the role
        var role = await _roleManager. FindByNameAsync(roleName);
        if (role == null) return NotFound(new ApiResponse(404));

        // Find the user
        var user = await _userManager.FindByNameAsync(userName);
        if (user == null) return NotFound(new ApiResponse(404));

        // Check if user is in role
        var isInRole = await _userManager.IsInRoleAsync(user, roleName);
        if (!isInRole) return NotFound(new ApiResponse(400));

        // Remove user from role
        var result = await _userManager.RemoveFromRoleAsync(user, roleName);
        if (result.Succeeded)
            return Ok($"User '{user.UserName}' successfully removed from role '{roleName}'.");
        else
            return NotFound(new ApiResponse(400));
    }
}
