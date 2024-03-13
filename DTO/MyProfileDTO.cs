using DataAccess.Data.Domains; 
using Utils.Enums;

namespace DTO;

public class MyProfileDTO
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Nickname { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    
}
