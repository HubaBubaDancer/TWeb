namespace TWeb.Models;

public class Admin : BaseDbItem
{
    public Guid AdminId { get; set; } // From Identity
    
    public Admin(Guid adminId)
    {
        AdminId = adminId;
    }
}