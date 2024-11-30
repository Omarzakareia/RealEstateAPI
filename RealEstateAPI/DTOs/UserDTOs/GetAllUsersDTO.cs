namespace RealEstateAPI.DTOs.UserDTOs;
public class GetAllUsersDTO
{
    public int Id { get; set; }
    public string? DisplayName { get; set; } = null!;
    public string? Email { get; set; } = null!;
    public List<string>? Roles { get; set; } = null!;
}
