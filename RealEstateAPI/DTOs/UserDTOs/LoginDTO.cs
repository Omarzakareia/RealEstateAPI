using System.ComponentModel.DataAnnotations;
namespace RealEstateAPI.DTOs.UserDTOs;
public record LoginDto(
    [Required]
    [EmailAddress]
    string Email,

    [Required]
    string Password
);
