using Microsoft.AspNetCore.Mvc;

namespace TWeb.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Cars()
    {
        return View();
    }
    
    public IActionResult About()
    {
        return View();
    }
    
    public IActionResult Contacts()
    {
        return View();
    }
    
    
}