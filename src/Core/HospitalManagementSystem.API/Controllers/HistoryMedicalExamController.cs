using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.API;

public class HistoryMedicalExamController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
