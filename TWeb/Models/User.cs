namespace TWeb.Models;

public class User : BaseDbItem
{
    public Guid UserId { get; set; } // From Identity
    public RentHistory RentHistory { get; set; }
    public string? LicenseNumber { get; set; }  
    public string? IdCardNumber { get; set; }
    
    
    public User(Guid userId)
    {
        UserId = userId;
        RentHistory = new RentHistory(userId);
    }
    
}