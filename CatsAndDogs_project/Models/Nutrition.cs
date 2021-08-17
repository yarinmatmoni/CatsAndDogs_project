using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class Nutrition
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "שם ")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "אורך השם חייב להכיל בין 3-50 תווים")]
        public string Name { get; set; }


        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "תיאור")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "אורך התיאור חייב להכיל בין 3-500 תווים")]
        public string Description { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "יתרונות")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "אורך הטיפ חייב להכיל בין 3-500 תווים")]
        public string Advantages { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "מתאים ל:")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "אורך הטיפ חייב להכיל בין 3-500 תווים")]
        public string matching { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "מחיר")]
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "צרף קישור לתמונה")]
        public String Image { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "בחר את סוג החיה")]
        public string Type { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "בחר קטגוריה")]
        public int CategoryId { get; set; }

        public NutritionCategory Category { get; set; }
    }
}
