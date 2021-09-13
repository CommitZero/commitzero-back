using Microsoft.AspNetCore.Mvc;
using CommitZeroBack.Data;

namespace CommitZeroBack.Controllers
{
    public class migrationController : Controller
    {
        [HttpGet]
        public IActionResult migrate() {
            return Content(DBMaker.Execute());
        }
    }
}