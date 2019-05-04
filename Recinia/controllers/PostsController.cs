using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Recinia.controllers
{
    public class PostsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetPost()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPost()
        {
            return View();
        }
    }
}