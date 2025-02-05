namespace TWeb.Models;

public class ItemHistory
{
    public Car Car { get; set; }
    public DateTime RentStart { get; set; }
    public DateTime RentEnd { get; set; }
    public decimal Price { get; set; }
}