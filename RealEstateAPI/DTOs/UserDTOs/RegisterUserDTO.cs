using System.ComponentModel.DataAnnotations;
namespace RealEstateAPI.DTOs.UserDTOs;
public record RegisterUserDto(
    [Required]
    [EmailAddress]
    string Email,

    [Required]
    string DisplayName,

    [Required]
    [RegularExpression("(?=^.{8,}$)((?=.*\\d)(?=.*\\W+))(?![.\\n])(?=.*[A-Z])(?=.*[a-z]).*$",
        ErrorMessage = "Password must contain 1 Uppercase, 1 Lowercase, 1 Digit, 1 Special Character")]
    string Password,
    [Phone]
    [Required]
    string PhoneNumber
);
