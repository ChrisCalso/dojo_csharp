using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wall.Models;
using System.Linq;
using DbConnection;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace wall.Controllers
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
                return Login(email, password);
                // HttpContext.Session.SetObjectAsJson("curr_user", newuser);
                // return Redirect("dashboard");
                
            }
            else
            {
                return View("index");
            }
        }

        [HttpGetAttribute]
        [RouteAttribute("dashboard")]
        public IActionResult Dashboard()
        {
            // ViewBag.Curr_user = HttpContext.Session.GetString("curr_user");
            ViewBag.Curr_user = HttpContext.Session.GetObjectFromJson<User>("curr_user");
            List<Dictionary<string, object>> all_messages = DbConnector.Query("SELECT id, user_id, message, created_at FROM messages");
            ViewBag.messages = all_messages;
            List<Dictionary<string, object>> all_comments = DbConnector.Query("SELECT message_id, user_id, comment, created_at FROM comments");
            Dictionary<int, List<string>> message_comment_dict = new Dictionary<int, List<string>>();
            foreach (Dictionary<string, object> comment in all_comments)
            {
                int parent_message_id = (int)comment["message_id"];
                if (!message_comment_dict.ContainsKey(parent_message_id))
                {
                    List<string> a_list = new List<string>();
                    message_comment_dict.Add(parent_message_id, a_list);
                }
                message_comment_dict[parent_message_id].Add((string)comment["comment"]);
            }
            ViewBag.message_comment_dict = message_comment_dict;
            return View();
        }


        [HttpPostAttribute]
        [RouteAttribute("login")]
        public IActionResult Login(string email, string password)
        {
            List<Dictionary<string, object>> users_in_db = DbConnector.Query("SELECT id, first_name, last_name, email, password from users");
            foreach (Dictionary<string, object> user_item in users_in_db)
            {
                if ((string)user_item["email"] == email && (string)user_item["password"] == password)
                {
                    HttpContext.Session.SetObjectAsJson("curr_user", user_item);
                    return Redirect("dashboard");
                }
            }
            ViewBag.errors = new List<string>();
            ViewBag.loginerror = "Invalid. Check spelling or register!";
            return View("index");
        }

        [HttpPostAttribute]
        [RouteAttribute("add-message")]
        public IActionResult AddMessage(string new_message)
        {
            int curr_user_id = HttpContext.Session.GetObjectFromJson<User>("curr_user").id;
            DbConnector.Execute($"INSERT INTO messages (message, created_at, updated_at, user_id) VALUES ('{new_message}', NOW(), NOW(), {curr_user_id})");
            return Redirect("dashboard");
        }

        [HttpPostAttribute]
        [RouteAttribute("add-comment")]
        public IActionResult AddComment(string new_comment, int message_id)
        {
            int curr_user_id = HttpContext.Session.GetObjectFromJson<User>("curr_user").id;
            DbConnector.Execute($"INSERT INTO comments (comment, created_at, updated_at, user_id, message_id) VALUES ('{new_comment}', NOW(), NOW(), {curr_user_id}, {message_id})");
            return Redirect("dashboard");
        }
        
        [HttpGetAttribute]
        [RouteAttribute("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}