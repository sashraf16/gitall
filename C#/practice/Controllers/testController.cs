using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practice.Models;

namespace practice.Controllers
{
    public class testController : Controller
    {
        //
        //GET: /test/
        public IActionResult Index()
        {
            ViewData["Message"] = "test page";
            return View();
        }
        
        //
        //GET: /test/method1
        public IActionResult method1()
        {
            ViewData["Message"] = "method1 page";
            return View();
        }
    }
}