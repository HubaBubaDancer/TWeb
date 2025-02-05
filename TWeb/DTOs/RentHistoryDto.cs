using TWeb.Models;

namespace TWeb.DTOs;

public class RentHistoryDto
{
    public List<ItemHistory> Items { get; set; }
    
    public RentHistoryDto()
    {
        Items = new List<ItemHistory>();
    }
}