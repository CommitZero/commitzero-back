using Microsoft.AspNetCore.Mvc;
using CommitZeroBack.Data;

namespace CommitZeroBack.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ValidateUser()
        {
            return View();
        }
    }
}