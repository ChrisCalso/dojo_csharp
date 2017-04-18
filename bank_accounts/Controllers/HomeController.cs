using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bank_accounts.Models;
using System.Linq;
using bank_accounts.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace bank_accounts.Controllers
{
    public class HomeController : Controller
    {
        private BankAccountContext _context;
 
        public HomeController(BankAccountContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            // List<Account> Accounts = _context.Accounts.Include(account => account.User).ToList();
            // List<Dictionary<string, object>> AllUsers = _dbConnector.Query("SELECT * FROM users");
            return View();
        }

        [HttpPostAttribute]
        [RouteAttribute("register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                User newuser = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password
                };
                _context.Add(newuser);
                _context.SaveChanges();
                Account newaccount = new Account
                {
                    Balance = 0,
                    Transaction = 0,
                    TransactionDate = DateTime.Now.ToString(),
                    UserId = newuser.UserId
                };
                _context.Add(newaccount);
                _context.SaveChanges();
                return LoggingIn(newuser.Email, newuser.Password);
                // Handle success
            }

            else
            {
            ViewBag.errors = ModelState.Values;
            return View("Index");
            }
        }

        [HttpPostAttribute]
        [RouteAttribute("logging-in")]
        public IActionResult LoggingIn(string email, string password)
        {
            List<User> ReturnedUser = _context.user.Where(user => user.Email == email && user.Password == password).ToList();
            if (ReturnedUser.Count > 0)
            {
                HttpContext.Session.SetObjectAsJson("curr_user", ReturnedUser[0]);
                return Redirect("dashboard");
            }
            else
            {
                ViewBag.LoginError = "User was not found with given email/password combo. Check or register!";
                return View("Login");
            }
            
        }

        [HttpGetAttribute]
        [RouteAttribute("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPostAttribute]
        [RouteAttribute("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }

        [HttpPostAttribute]
        [RouteAttribute("withdrawdeposit")]
        public IActionResult WithdrawDeposit(int withdrawdeposit)
        {
            HttpContext.Session.SetInt32("withdrawdepositAmount", withdrawdeposit);
            List<Account> curr_account = HttpContext.Session.GetObjectFromJson<List<Account>>("curr_account");
            User current_user = HttpContext.Session.GetObjectFromJson<User>("curr_user");
            double balance = curr_account[0].Balance;
            if(HttpContext.Session.GetInt32("withdrawdepositAmount") != 0 && HttpContext.Session.GetInt32("withdrawdepositAmount") >= -balance)
            {
                Account newaccount = new Account
                    {
                        Balance = curr_account[curr_account.Count - 1].Balance + (double)HttpContext.Session.GetInt32("withdrawdepositAmount"),
                        Transaction = (double)HttpContext.Session.GetInt32("withdrawdepositAmount"),
                        TransactionDate = DateTime.Now.ToString(),
                        UserId = current_user.UserId
                    };
                    _context.Add(newaccount);
                    _context.SaveChanges();
            }
            return Redirect("dashboard");
        }

        [HttpGetAttribute]
        [RouteAttribute("dashboard")]
        public IActionResult Dashboard()
        {
            // ViewBag.Number = HttpContext.Session.GetInt32("withdrawdepositAmount");
            ViewBag.Curr_user = HttpContext.Session.GetObjectFromJson<User>("curr_user");
            User current_user = HttpContext.Session.GetObjectFromJson<User>("curr_user");
            List<Account> ReturnedAccount = _context.account.Where(account => account.UserId == current_user.UserId).ToList();
            HttpContext.Session.SetObjectAsJson("curr_account", ReturnedAccount);
            ViewBag.AccountInfo = ReturnedAccount;
            return View();
        }
    }
}


