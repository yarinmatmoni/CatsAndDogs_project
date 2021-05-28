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

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name ="שם ")]
        [StringLength(50,MinimumLength =3 , ErrorMessage ="אורך השם חייב להחיל בין 3-50 תווים")]
        public String Name { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "גזע")]
        public String Type { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "גיל")]
        public int Age { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "גודל")]
        public String Size { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "מין")]
        public String Gender { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "צבע")]
        public String Color { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "תוחלת חיים")]
        public String LifeExpectancy { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "התאמה")]
        public String Match { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "תיאור")]
        [StringLength(200, MinimumLength = 10 , ErrorMessage ="התיאור חייב להחיל בין 20-200 תווים")]
        public String Description { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "צרף קישור לתמונה")]
        public String Image { get; set; }

    }
}
