using Microsoft.AspNetCore.Mvc;
using TWeb.DTOs;
using TWeb.Models;
using TWeb.Services;

namespace TWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : Controller
{
    
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }
    
    [HttpPost("add-car")]
    public async Task<IActionResult> AddCar([FromBody] CarDto car)
    {
        return await _adminService.AddCar(car);
    }
    
    [HttpDelete("remove-car/{id}")]
    public async Task<IActionResult> RemoveCar([FromBody] Guid id)
    {
        return await _adminService.RemoveCar(id);
    }
    
    public async Task<List<User>> GetUsers()
    {
        return await _adminService.GetUsers();
    }
    
    
    [HttpGet("get-user/{id}")]
    public async Task<User> GetUser(Guid id)
    {
        return await _adminService.GetUser(id);
    }
    
    
    
    
    
}