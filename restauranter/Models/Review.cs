using System;
using System.ComponentModel.DataAnnotations;

namespace restauranter.Models
{
    public abstract class BaseEntity {}
    public class Review
    {
        public int ReviewId { get; set; }

        [Required]
        public string ReviewerName { get; set; }
        
        [Required]
        public string RestaurantName { get; set; }

        [Required]
        [MinLengthAttribute(10)]
        public string ReviewContent { get; set; }
 
        [Required]
        public string DateOfVisit { get; set; }

        [RequiredAttribute]
        public string StarRating { get; set; }

    }
}