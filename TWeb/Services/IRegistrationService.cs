using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TWeb.Areas.Identity.Data;
using TWeb.DTOs;
using TWeb.Models;

namespace TWeb.Services;

public interface IRegistrationService
{
    public Task RegisterUser(RegisterModel model);
    public Task RegisterAdmin(RegisterModel admin);
}


public class RegistrationService : IRegistrationService
{
    private readonly TWebDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public RegistrationService(TWebDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _context = context;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task RegisterUser(RegisterModel model)
    {
        var user = new ApplicationUser
        {
            UserName = model.FirstName,
            Email = model.Email,
            PhoneNumber = model.Phone,
            FirstName = model.FirstName,
            LastName = model.LastName
        };
        
        var result = await _userManager.CreateAsync(user, model.Password);
        
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");
            var userToDb = _mapper.Map<User>(user);
            await _context.Users.AddAsync(userToDb);
            await _context.SaveChangesAsync();
        }
    }
    
    
    //TODO: TEST
    
    public async Task RegisterAdmin(RegisterModel model)
    {
        var user = new ApplicationUser
        {
            UserName = model.FirstName,
            Email = model.Email,
            PhoneNumber = model.Phone,
            FirstName = model.FirstName,
            LastName = model.LastName
        };
        
        var result = await _userManager.CreateAsync(user, model.Password);
        
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "Admin");
            var admin = _mapper.Map<Admin>(user);
            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();
        }
    }

}