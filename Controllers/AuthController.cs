using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CommitZeroBack.Models;

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
