using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.API;

public class PatientController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
