using Microsoft.AspNetCore.Mvc;
using CommitZeroBack.Models;
using CommitZeroBack.Data;
using System;

namespace CommitZeroBack.Controllers
{
    public class authController : Controller
    {
        /*
            Header "CommitZero-Key" - Necessário para todas as ações dentro do site
         */
        [HttpPost]
        public IActionResult userLogin([FromBody] LoginRequest RequestRaw)
        {
            if(Request.Headers["API_KEY"] == ConfigManager.api_key()) {
                return Content(Login.Execute(RequestRaw.username, RequestRaw.password));
            }
            else {
                return Unauthorized();
            }
        }

        [HttpGet]
        public IActionResult validateUser() {
            if(Request.Headers["API_KEY"] == ConfigManager.api_key()) {
                return Content(ValidateLogin.Execute(Request.Headers["Authorization"]).ToString());
            }
            return Unauthorized();
        }
    }
}
