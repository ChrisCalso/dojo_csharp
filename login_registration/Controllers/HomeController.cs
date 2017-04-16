using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using login_registration.Models;
using System.Linq;
using DbConnection;

namespace login_registration.Controllers
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
        [Route("register")]
        public IActionResult Register(string first_name, string last_name, string email, string password, string password_conf)
        {
            User newuser = new User
            {
                First_Name = first_name,
                Last_Name = last_name,
                Email = email,
                Password = password,
                PasswordConfirmation = password_conf

            };
            TryValidateModel(newuser);
            ViewBag.errors = ModelState.Values;
            if (ModelState.IsValid)
            {
                DbConnector.Execute($"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES ('{first_name}', '{last_name}', '{email}', '{password}', NOW(), NOW())");
                return View();
                
            }
            else
            {
                return View("index");
            }
        }

        [HttpPostAttribute]
        [RouteAttribute("login")]
        public IActionResult Login(string email, string password)
        {
            List<Dictionary<string, object>> users_in_db = DbConnector.Query("SELECT email, password from users");
            foreach (Dictionary<string, object> user_item in users_in_db)
            {
                if ((string)user_item["email"] == email && (string)user_item["password"] == password)
                {
                    return View("register");
                }
            }
            ViewBag.errors = new List<string>();
            ViewBag.loginerror = "Invalid. Check spelling or register!";
            return View("index");
        }
    }
}