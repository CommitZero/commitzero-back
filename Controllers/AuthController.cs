using Microsoft.AspNetCore.Mvc;
using CommitZeroBack.Models;
using CommitZeroBack.Data;

namespace CommitZeroBack.Controllers
{
    public class AuthController : Controller
    {
        /*
            Header "CommitZero-Key" - Necessário para todas as ações dentro do site
         */
        [HttpPost]
        public IActionResult UserLogin([FromBody] LoginRequest RequestRaw)
        {
            if(Request.Headers["CommitZero-Key"] == Globals.CommitZeroKey) {
                return Content(Login.Execute(RequestRaw.username, RequestRaw.password));
            }
            else {
                return Unauthorized();
            }
        }
    }
}
