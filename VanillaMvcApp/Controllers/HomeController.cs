using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VanillaMvcApp.Models;

namespace VanillaMvcApp.Controllers;

public class HomeController : Controller {
    private readonly string _htmlFilePath = 
                        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "html");

    public HomeController() {

    }

    public IActionResult Index() {
        var filePath = Path.Combine(_htmlFilePath, "index.html");
        
        return PhysicalFile(filePath, "text/html");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
