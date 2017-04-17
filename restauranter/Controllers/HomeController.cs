using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using restauranter.Models;
using System.Linq;
namespace restauranter.Controllers
{
    public class HomeController : Controller
    {
        private ReviewContext _context;
 
        public HomeController(ReviewContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // List<Dictionary<string, object>> AllUsers = _dbConnector.Query("SELECT * FROM users");
            return View();
        }

        [HttpPostAttribute]
        [RouteAttribute("new-review")]
        public IActionResult Create(string ReviewerName, string RestaurantName, string ReviewContent, string DateOfVisit, string StarRating)
        {
            Review NewReview = new Review
            {
                ReviewerName = ReviewerName,
                RestaurantName = RestaurantName,
                ReviewContent = ReviewContent,
                DateOfVisit = DateOfVisit,
                StarRating = StarRating
            };
            _context.Add(NewReview);
            _context.SaveChanges();
            return Redirect("reviews");
        }

        [HttpGetAttribute]
        [RouteAttribute("reviews")]
        public IActionResult ShowReviews()
        {
            List<Review> allreviews = _context.review.ToList();
            var orderedReviews = allreviews.OrderBy(item=>item.DateOfVisit).Reverse();
            ViewBag.AllReviews = orderedReviews;
            return View();
        }
    }
}


