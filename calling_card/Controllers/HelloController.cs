using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace CallingCard.Controllers
{
    public class HelloController : Controller
    {
        // [HttpGet]
        // A GET method
        [HttpGet]
        [Route("index")]
        public string Index()
        {
            return "Hello World!";
        }

        [HttpGet]
        [Route("other")]
        public string Other()
        {
            return "Other route";
        }
        
        [HttpGet]
        [Route("jsonresult")]
        public JsonResult Example()
        {
            // The Json method convert the object passed to it into JSON
            var AnonObject = new {
                         FirstName = "Raz",
                         LastName = "Aquato",
                         Age = 10
                     };
            return Json(AnonObject);
        }
        // A POST method
        // [HttpPost]
        // [Route("")]
        // public IActionResult Other()
        // {
        //     // Return a view (We'll learn how soon!)
        // }
        [HttpGet]
        [Route("callingcard/{first_name}/{last_name}/{age}/{fav_color}")]
        public JsonResult CallingCard(string first_name, string last_name, int age, string fav_color)
        {
            // The Json method convert the object passed to it into JSON
            var AnonObject = new {
                         FirstName = first_name,
                         LastName = last_name,
                         Age = age,
                         FavoriteColor = fav_color
                     };
            return Json(AnonObject);
        }
    }
}