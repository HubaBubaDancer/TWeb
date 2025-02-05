using AutoMapper;
using TWeb.Areas.Identity.Data;
using TWeb.DTOs;
using TWeb.Models;

namespace TWeb;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<RentHistory, RentHistoryDto>();
        CreateMap<ApplicationUser, UserDto>();
        CreateMap<User, UserDto>();
        CreateMap<Car, CarDto>();
        CreateMap<CarDto, Car>();
        CreateMap<ApplicationUser, Admin>();
    }
}