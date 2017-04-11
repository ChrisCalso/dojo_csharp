using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DbConnection;

namespace quoting_dojo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("submit-quote")]
        public IActionResult Submit(string name, string quote)
        {
            DbConnector.Execute($"INSERT INTO quotes (name, quote, created_at, updated_at) VALUES ('{name}', '{quote}', NOW(), NOW())");
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            List<Dictionary<string, object>> AllUsers = DbConnector.Query("SELECT name, quote, created_at FROM quotes");
            ViewBag.users = AllUsers;
            return View();
        }
    }
}
