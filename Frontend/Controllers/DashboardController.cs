using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
  public class DashboardController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
    public IActionResult Items()
    {
      return View();
    }
    public IActionResult Employees()
    {
      return View();
    }
  }
}