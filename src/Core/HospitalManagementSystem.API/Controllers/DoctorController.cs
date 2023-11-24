using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.API;

public class DoctorController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
