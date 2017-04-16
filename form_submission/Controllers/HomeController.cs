using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using form_submission.Models;
using System.Linq;

namespace form_submission.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            return View();
        }

        [HttpPost]
        [Route("")]
        public IActionResult Success(string first_name, string last_name, string age, string email, string password)
        {
            User newuser = new User
            {
                First_Name = first_name,
                Last_Name = last_name,
                Age = age,
                Email = email,
                Password = password

            };
            TryValidateModel(newuser);
            ViewBag.errors = ModelState.Values;
            if (ModelState.IsValid)
            {
                return View();
                
            }
            
            else
            {
                return View("Index");
            }
        }
    }
}
