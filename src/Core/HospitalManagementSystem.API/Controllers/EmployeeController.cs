using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.API;

public class EmployeeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
