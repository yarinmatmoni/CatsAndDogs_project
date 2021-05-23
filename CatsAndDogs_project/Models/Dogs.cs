using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class Dogs
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="שם ")]
        public String Name { get; set; }

        [Required]
        [Display(Name = "גזע")]
        public String Type { get; set; }

        [Required]
        [Display(Name = "גיל")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "גודל")]
        public String Size { get; set; } // big / medum / small

        [Required]
        [Display(Name = "מין")]
        public String Gender { get; set; }

        [Required]
        [Display(Name = "צבע")]
        public String Color { get; set; }

        [Required]
        [Display(Name = "תוחלת חיים")]
        public String LifeExpectancy { get; set; }

        [Required]
        [Display(Name = "התאמה")]
        public String Match { get; set; } // family / apartment / children .... 

        [Required]
        [Display(Name = "תיאור")]
        public String Description { get; set; }

        [Required]
        [Display(Name = "צרף קישור לתמונה")]
        public String Image { get; set; }
    }
}
