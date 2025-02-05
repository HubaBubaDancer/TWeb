using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using TWeb.DTOs;
using TWeb.Models;
using TWeb.Services;

namespace TWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegistrationController : Controller
{
    
    private readonly IRegistrationService _registration;

    public RegistrationController(IRegistrationService registration)
    {
        _registration = registration;
    }
    
    [AllowAnonymous]
    [HttpPost("/register-user")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            await _registration.RegisterUser(model);
        }
        
        return Ok();
    } 
    
    [Authorize(Roles = "SuperAdmin, Admin")]
    [HttpPost("/register-admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel admin)
    {
        await _registration.RegisterAdmin(admin);
        return Ok();
    }
    
    
}