namespace TWeb.Models;

public class RentHistory
{
    public Guid UserId { get; set; }
    public List<ItemHistory> Items { get; set; }
    
    public RentHistory(Guid userId)
    {
        UserId = userId;
        Items = new List<ItemHistory>();
    }
}