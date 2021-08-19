using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class Dog_2
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "שם ")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "אורך השם חייב להכיל בין 3-50 תווים")]
        public string Name { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "גזע")]
        public List<Breed_2> ListBreed { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "גיל")]
        public int Age { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "גודל")]
        public string Size { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "מין")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "צבע")]
        public string Color { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "תוחלת חיים")]
        public string LifeExpectancy { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "התאמה")]
        public string Match { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "תיאור")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "התיאור חייב להכיל בין 20-200 תווים")]
        public string Description { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "צרף קישור לתמונה")]
        public string Image { get; set; }

    }
}
