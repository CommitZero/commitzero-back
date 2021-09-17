using Microsoft.AspNetCore.Mvc;
using CommitZeroBack.Models;
using System.Configuration;
using System.IO;
using System.Text;

namespace CommitZeroBack.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult Teste() {
            var config_content = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + @"/environment.json");
            return Content("");
        }
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

        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FetchPosts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchPosts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeletePost()
        {
            return View();
        }
    }
}