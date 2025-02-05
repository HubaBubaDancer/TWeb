using Microsoft.EntityFrameworkCore;
using TWeb.Models;

namespace TWeb;

public class TWebDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<RentHistory> RentHistories { get; set; }
    public DbSet<Admin> Admins { get; set; }
    
    public TWebDbContext(DbContextOptions options) : base(options)
    {
    }
}