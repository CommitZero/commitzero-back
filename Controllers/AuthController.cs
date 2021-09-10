using Microsoft.AspNetCore.Mvc;

namespace CommitZeroBack.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return Content("Vazio");
        }
    }
}
