namespace RealEstateAPI.DTOs;
public class CallRequestDTO
{
    public int? Id { get; set; }
    public string? Name { get; set; }         
    public string? PhoneNumber { get; set; }  
    public int? PropertyId { get; set; }     
    public string? PropertyTitle { get; set; } 
    public int? ProjectId { get; set; }       
    public string? ProjectName { get; set; }  
    public DateTime? RequestDate { get; set; } 
}
public class AddCallRequestDTO
{
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public int? PropertyId { get; set; }
    public int? ProjectId { get; set; }
}
