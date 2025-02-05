namespace TWeb.DTOs;

public class CarDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public List<string>? PhotoPaths { get; set; } = new List<string>();
    public bool IsHidden { get; set; } 
}