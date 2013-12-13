using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace quotetrail.Models
{
    public class Quote
    {
        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Quoted By")]
        public string QuoteBy { get; set; }

        [Required]
        [Display(Name = "Quote String")]
        public string Quotestring { get; set; }

        [Required]
        [Display(Name = "Entered By")]
        public String User { get; set; }       

    }
}