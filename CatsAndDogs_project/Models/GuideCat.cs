using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class GuideCat
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [RegularExpression(@"(https?:\/\/)?(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#()?&//=]*)", ErrorMessage = "ניתן לשים אך ורק קישור")]
        [Display(Name = "צרף תמונה לגזע")]
        public string ImageGuied { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [RegularExpression(@"(https?:\/\/)?(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#()?&//=]*)", ErrorMessage = "ניתן לשים אך ורק קישור")]
        [Display(Name = "צרף תמונה למדריך")]
        public string Image { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "גזע")]
        public int BreedCat_2Id { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "גזע")]
        public BreedCat_2 BreedCat { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [MinLength(50, ErrorMessage = "התיאור חייב להכיל לפחות 50 תווים")]
        [Display(Name = "תיאור כללי")]
        public string Description { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [MinLength(50, ErrorMessage = "תיאור תכונות האופי חייב להכיל לפחות 50 תווים")]
        [Display(Name = "תכונות אופי")]
        public string Characteristics { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [MinLength(50, ErrorMessage = "תיאור הבראיות חייב להכיל לפחות 50 תווים")]
        [Display(Name = "בריאות")]
        public string Health { get; set; }

    }
}
