using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class GuideDog
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
        public int Breed_2Id { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "שם הגזע חייב להכיל בין 3-50 תווים")]
        [Display(Name = "גזע")]
        public Breed_2 BreedDog { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "תוחלת החיים חייבת להכיל בין 1-5 תווים")]
        [Display(Name = "תוחלת חיים ממוצעת")]
        public string AvgLife { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "המשקל הממוצע חייב להכיל בין 1-5 תווים")]
        [Display(Name = "משקל ממוצע")]
        public string AvgWeight { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [StringLength(7, MinimumLength = 1, ErrorMessage = "הגובה הממוצע חייב להכיל בין 1-7 תווים")]
        [Display(Name = "גובה גזע")]
        public string AvgHeight { get; set; }

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

        [Required(ErrorMessage = "זהו שדה חובה")]
        [MinLength(50, ErrorMessage = "תיאור האילוף חייב להכיל לפחות 50 תווים")]
        [Display(Name = "אילוף")]
        public string Training { get; set; }
    }
}
