namespace TWeb.Models;

public class RentCarRequest
{
    public Guid CarId { get; set; }
    public Guid UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}