using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;

namespace Dojodachi.Controllers
{
    public static class SessionExtensions
{
    // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
    public static void SetObjectAsJson(this ISession session, string key, object value)
    {
        // This helper function simply serializes theobject to JSON and stores it as a string in session
        session.SetString(key, JsonConvert.SerializeObject(value));
    }
       
    // generic type T is a stand-in indicating that we need to specify the type on retrieval
    public static T GetObjectFromJson<T>(this ISession session, string key)
    {
        string value = session.GetString(key);
        // Upone retrieval the object is deserialized based on the type we specified
        return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
    }
}
    public class Dojodachi : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetObjectFromJson<Dachi>("CurrDachi") == null)
            {
                Dachi dojo = new Dachi();
                HttpContext.Session.SetObjectAsJson("CurrDachi", dojo);
                ViewBag.fullness = dojo.fullness;
                ViewBag.happiness = dojo.happiness;
                ViewBag.meals = dojo.meals;
                ViewBag.energy = dojo.energy;
            }

            // If energy, fullness, and happiness are all raised to over 100, you win! a restart button should be displayed.
            else if (HttpContext.Session.GetObjectFromJson<Dachi>("CurrDachi").fullness >= 100 && HttpContext.Session.GetObjectFromJson<Dachi>("CurrDachi").happiness >= 100 && HttpContext.Session.GetObjectFromJson<Dachi>("CurrDachi").energy >= 100)
            {
                return RedirectToAction("Win");
            }

            // If fullness or happiness ever drop to 0, you lose, and a restart button should be displayed.
            else if (HttpContext.Session.GetObjectFromJson<Dachi>("CurrDachi").fullness == 0 || HttpContext.Session.GetObjectFromJson<Dachi>("CurrDachi").happiness == 0)
            {
                return RedirectToAction("Lose");
            }

            else
            {
                ViewBag.fullness = HttpContext.Session.GetObjectFromJson<Dachi>("CurrDachi").fullness;
                ViewBag.happiness = HttpContext.Session.GetObjectFromJson<Dachi>("CurrDachi").happiness;
                ViewBag.meals = HttpContext.Session.GetObjectFromJson<Dachi>("CurrDachi").meals;
                ViewBag.energy = HttpContext.Session.GetObjectFromJson<Dachi>("CurrDachi").energy;
            }
            return View();
        }

        [HttpGet]
        [Route("win")]
        public IActionResult Win()
        {
            return View();
        }

        [HttpGet]
        [Route("lose")]
        public IActionResult Lose()
        {
            return View();
        }

        [HttpPost]
        [Route("restart")]
        public IActionResult Restart()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        // Feeding your Dojodachi costs 1 meal and gains a random amount of fullness between 5 and 10 (you cannot feed your Dojodachi if you do not have meals)
        [HttpPost]
        [Route("feed")]
        public IActionResult Feed()
        {
            Dachi dojo = HttpContext.Session.GetObjectFromJson<Dachi>("CurrDachi");
            Random chance = new Random();
            if (chance.Next(1, 5) == 1)
            {
                if (dojo.meals != 0)
                {
                    Random rand = new Random();
                    dojo.meals = dojo.meals - 1;
                    dojo.fullness += rand.Next(5, 11);
                }
            }

            else
            {
                dojo.meals = dojo.meals - 1;
            }
            
            HttpContext.Session.SetObjectAsJson("CurrDachi", dojo);
            return RedirectToAction("Index");
        }

        // Playing costs 5 energy and gains a random amount of happiness between 5 and 10 
        // Every time you play with or feed your dojodachi there should be a 25% chance that it won't like it. Energy or meals will still decrease, but happiness and fullness won't change.
        [HttpPost]
        [Route("play")]
        public IActionResult Play()
        {
            Dachi dojo = HttpContext.Session.GetObjectFromJson<Dachi>("CurrDachi");
            Random chance = new Random();
            if (chance.Next(1, 5) == 1)
            {
                Random rand = new Random();
                dojo.energy = dojo.energy - 5;
                dojo.happiness += rand.Next(5, 11);
            }
            
            else
            {
                dojo.energy = dojo.energy - 5;
            }

            HttpContext.Session.SetObjectAsJson("CurrDachi", dojo);
            return RedirectToAction("Index");
        }

        // Working costs 5 energy and earns between 1 and 3 meals
        [HttpPost]
        [Route("work")]
        public IActionResult Work()
        {
            Dachi dojo = HttpContext.Session.GetObjectFromJson<Dachi>("CurrDachi");
            Random rand = new Random();
            dojo.energy = dojo.energy - 5;
            dojo.meals += rand.Next(1, 4);
            HttpContext.Session.SetObjectAsJson("CurrDachi", dojo);
            return RedirectToAction("Index");
        }

        // Sleeping earns 15 energy and decreases fullness and happiness each by 5
        [HttpPost]
        [Route("sleep")]
        public IActionResult Sleep()
        {
            Dachi dojo = HttpContext.Session.GetObjectFromJson<Dachi>("CurrDachi");
            Random rand = new Random();
            dojo.energy = dojo.energy + 15;
            dojo.fullness = dojo.fullness - 5;
            dojo.happiness = dojo.happiness - 5;
            HttpContext.Session.SetObjectAsJson("CurrDachi", dojo);
            return RedirectToAction("Index");
        }
    }
}