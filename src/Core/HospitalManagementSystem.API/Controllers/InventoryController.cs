using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.API;

public class InventoryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
