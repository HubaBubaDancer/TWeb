using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TWeb.DTOs;
using TWeb.Models;

namespace TWeb.Services;

public interface IRentService
{
    Task<IActionResult> RentCar(Guid carId, Guid userId, DateTime startDate, DateTime endDate);
    Task<RentHistoryDto> GetRentHistory(Guid userId);
    Task<List<CarDto>> GetAvailableCars();
    Task<CarDto> GetCarById(Guid id);
}


public class RentService : IRentService
{
    private readonly TWebDbContext _context;
    private readonly IMapper _mapper;

    public RentService(TWebDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IActionResult> RentCar(Guid carId, Guid userId, DateTime startDate, DateTime endDate)
    {
        // TODO
        return new OkResult();
    }

    public async Task<RentHistoryDto> GetRentHistory(Guid userId)
    {
        
        var rentHistory = new RentHistoryDto();
        var rentHistoryInfo = await _context.RentHistories.FindAsync(userId);

        if (rentHistoryInfo != null)
        {
            rentHistory = _mapper.Map<RentHistoryDto>(rentHistoryInfo);
            return rentHistory;
        }

        return null;
    }
    
    public async Task<List<CarDto>> GetAvailableCars()
    {
        var cars = await _context.Cars.Where(c => c.IsHidden == false).ToListAsync();
        var carDtos = _mapper.Map<List<CarDto>>(cars);
        return carDtos;
    }

    public async Task<CarDto> GetCarById(Guid id)
    {
        var car = _context.Cars.FirstOrDefault(c => c.Id == id);
        if (car == null) return null;
        
        var carDto = _mapper.Map<CarDto>(car);
        return carDto;
    }
    
    
}