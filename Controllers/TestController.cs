using Microsoft.AspNetCore.Mvc;

namespace CommitZeroBack.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}