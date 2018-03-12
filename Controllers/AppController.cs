using System;
using coreapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace coreapp.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact us";
            //throw new Exception("Bad things happen");
            return View();
        }
       
        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            return View();
        }

        [HttpGet("product")]
        public IActionResult Product()
        {
            ViewBag.Title = "Contact us";
            //throw new Exception("Bad things happen");
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Shop()
        {
          try
          {
            
            return Ok();
          }
          catch (Exception)
          {
            return BadRequest();
          }
        }
    }
}
