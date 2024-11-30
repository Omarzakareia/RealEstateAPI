namespace OrderManagementSystem.DTOs.UserDTOs;
public class UserDTO
{
    public int Id { get; set; } 
    public string DisplayName { get; set; } =null!;
    public string Email { get; set; } = null!;
    public List<string> Roles { get; set; } // List to store roles
    public string Token { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;

}