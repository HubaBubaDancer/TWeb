using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TWeb;
using TWeb.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TWebDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("MainConnection"));
});

builder.Services.AddDbContext<AuthDbContext>(options => options.UseNpgsql("AuthConnection"));
builder.Services.AddDefaultIdentity<ApplicationUser>(o => o.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();


/*
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "Doctor", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    string email = "demouser@test.test";
    string password = "Test123!";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser()
        {
            UserName = email, 
            Email = email, 
            EmailConfirmed = true, 
            FirstName = "Demo", 
            LastName = "User"
        };
        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Admin");
    }
}
*/
app.Run();