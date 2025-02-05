using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TWeb.Areas.Identity.Data;
using TWeb.DTOs;
using TWeb.Models;

namespace TWeb.Services;

public interface IAdminService
{
    Task<IActionResult> AddCar(CarDto car);
    Task<IActionResult> RemoveCar(Guid id);
    Task<List<User>> GetUsers();
    Task<User> GetUser(Guid id);
    Task<IActionResult> UpdateCar(CarDto car, Guid id);
}


public class AdminService : IAdminService
{
    private readonly TWebDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public AdminService(TWebDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _context = context;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<IActionResult> AddCar(CarDto car)
    {
        var newCar = _mapper.Map<Car>(car);
        await _context.Cars.AddAsync(newCar);
        await _context.SaveChangesAsync();
        
        return new OkResult();
    }

    public async Task<IActionResult> RemoveCar(Guid id)
    {   
        var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);

        if (car == null) return new OkResult();
        
        car.IsHidden = true;
        _context.Cars.Update(car);
        await _context.SaveChangesAsync();
        return new OkResult();
    }

    public async Task<List<User>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }
    
    public async Task<User> GetUser(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        
        if (user != null)
        {
            var userInfo = await _context.Users.FindAsync(id);
            
            return userInfo;
        }
        
        return null;
    }
    
    
    public async Task<IActionResult> UpdateCar(CarDto car, Guid id)
    {
        var carToUpdate = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);

        if (carToUpdate == null) return new OkResult();
        
        carToUpdate = _mapper.Map<Car>(car);
        _context.Cars.Update(carToUpdate);
        await _context.SaveChangesAsync();
        return new OkResult();
    }
    
    
}