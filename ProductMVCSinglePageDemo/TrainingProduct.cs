using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProductMVCSinglePageDemo
{
    public class TrainingProduct
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage ="ProductName Must be filled in.")]
        [Display(Description="Product Name")]
        [StringLength(150,MinimumLength =4,ErrorMessage ="{0} must be greaterthen {2} and lassthan {1} characters")]
        public string ProductName { get; set; }
        [Range(typeof(DateTime),"1/1/2000","12/30/2020",ErrorMessage ="{0} must be in between {1} and {2}")]
        [Display(Description ="Introduction Date")]
        public DateTime Introductiondate { get; set; }
        [Required(ErrorMessage ="URL Must be entered")]
        [Display(Description = "URL")]
        [StringLength(2000, MinimumLength = 5, ErrorMessage = "{0} must be greaterthen {2} and lassthan {1} characters")]
        public string Url { get; set; } 
        [Range(1,99999,ErrorMessage="{0} must be in between {1} and {2}")]
        public decimal Price { get; set; }
    }
}
