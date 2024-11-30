using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.DTOs.UserDTOs;
using RealEstate.Core.Entities.Identity;
using RealEstate.Core.Services;
using RealEstateAPI.DTOs.UserDTOs;
using RealEstateAPI.Errors;
using System.Security.Claims;
namespace RealEstateAPI.Controllers;
public class AccountController : ApiBaseController
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    public AccountController(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager, ITokenService tokenService,
        IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _mapper = mapper;
    }
    //BaseUrl/Account/Register
    // Register 
    #region Register
    [HttpPost("Register")]
    public async Task<ActionResult<UserDTO>> Register(RegisterUserDto model)
    {
        if (CheckEmailExists(model.Email).Result.Value)
        {
            return BadRequest(new ApiResponse(400, "Email is Already Exists"));
        }

        var User = new AppUser()
        {
            DisplayName = model.DisplayName,
            Email = model.Email,
            UserName = model.Email.Split('@')[0],
            PhoneNumber = model.PhoneNumber
        };
        var Result = await _userManager.CreateAsync(User, model.Password);
        if (!Result.Succeeded) return BadRequest(new ApiResponse(400));
        var ReturnedUser = new UserDTO()
        {
            DisplayName = User.DisplayName,
            Email = User.Email,
            PhoneNumber = User.PhoneNumber,
            Token = await _tokenService.CreateTokenAsync(User, _userManager)
        };
        return Ok(ReturnedUser);
    }
    #endregion

    // Login
    #region Login     
    [HttpPost("Login")]
    public async Task<ActionResult<UserDTO>> Login(LoginDto model)
    {
        var User = await _userManager.FindByEmailAsync(model.Email);
        if (User == null) return Unauthorized(new ApiResponse(401));

        var Result = await _signInManager.CheckPasswordSignInAsync(User, model.Password, false);
        if (!Result.Succeeded) return Unauthorized(new ApiResponse(401));
        return Ok(new UserDTO()
        {
            DisplayName = User.DisplayName,
            Email = User.Email,
            PhoneNumber = User.PhoneNumber,
            Token = await _tokenService.CreateTokenAsync(User, _userManager)             
        });
    }
    #endregion
    [Authorize]
    [HttpGet("GetCurrentUser")]
    // BaseUrl/Api/Accounts/GetCurrentUser
    public async Task<ActionResult<UserDTO>> GetCurrentUser()
    {
        var Email = User.FindFirstValue(ClaimTypes.Email);
        var user = await _userManager.FindByEmailAsync(Email);
        var ReturnedObject = new UserDTO()
        {
            DisplayName = user.DisplayName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Token = await _tokenService.CreateTokenAsync(user, _userManager)
        };
        return Ok(ReturnedObject);
    }
    [HttpGet("emailExists")]
    public async Task<ActionResult<bool>> CheckEmailExists(string Email)
    {
        return await _userManager.FindByEmailAsync(Email) is not null;
    }
}
