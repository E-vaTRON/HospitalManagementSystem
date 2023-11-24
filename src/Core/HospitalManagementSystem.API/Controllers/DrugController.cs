using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.API;

public class DrugController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
