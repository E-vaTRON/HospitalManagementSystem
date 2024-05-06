using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.API;

public class PatientTransactionHistoryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
