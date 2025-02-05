using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TWeb.Models;
using TWeb.Services;

namespace TWeb.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ClientController : Controller
{

    private readonly IRentService _rent;

    public ClientController(IRentService rent)
    {
        _rent = rent;
    }
    
    [HttpGet("/rent-history/{userId}")]
    public async Task<IActionResult> GetRentHistory(Guid userId)
    {
        var rentHistory = await _rent.GetRentHistory(userId);
        return Ok(rentHistory);
    }
    
    [HttpPost("/rent-car")]
    public async Task<IActionResult> RentCar([FromBody] RentCarRequest rentCarDto)
    {
        var result = await _rent.RentCar(rentCarDto.CarId, rentCarDto.UserId, rentCarDto.StartDate, rentCarDto.EndDate);
        return result;
    }
    
    [AllowAnonymous]
    [HttpGet("/available-cars")]
    public async Task<IActionResult> GetAvailableCars()
    {
        var cars = await _rent.GetAvailableCars();
        return Ok(cars);
    }
    
    [AllowAnonymous]
    [HttpGet("/get-car/{id}")]
    public async Task<IActionResult> GetCarById(Guid id)
    {
        var car = await _rent.GetCarById(id);
        return Ok(car);
    }
    
    
    
}