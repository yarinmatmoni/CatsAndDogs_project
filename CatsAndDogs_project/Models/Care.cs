using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class Care
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
        [Display(Name = "חשוב לנו שתדעו!")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "אורך הטיפ חייב להכיל בין 3-500 תווים")]
        public string Tip { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "מחיר")]
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        [RegularExpression(@"(https?:\/\/)?(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#()?&//=]*)", ErrorMessage = "ניתן לשים אך ורק קישור")]
        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "צרף קישור לתמונה")]
        public String Image { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "בחר את סוג החיה")]
        public string Type { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "בחר קטגוריה")]
        public int CategoryId { get; set; }

        public CareCategory Category { get; set; }
    }
}
