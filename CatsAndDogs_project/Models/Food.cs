using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class Food
    {
        public int Id { get; set; }

        [Display(Name = "שם המוצר:")]
        [Required(ErrorMessage = "זהו שדה חובה")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "אורך השם חייב להחיל בין 3-50 תווים")]
        public string Name { get; set; }

        [Display(Name = "תיאור:")]
        [Required(ErrorMessage = "זהו שדה חובה")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "התיאור חייב להחיל בין 10-300 תווים")]
        public string Description { get; set; }


        [Display(Name = "חשוב לנו שתדעו:")]
        [Required(ErrorMessage = "זהו שדה חובה")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "הטיפ חייב להחיל בין 10-300 תווים")]
        public string Tips { get; set; }

        [Display (Name="מחיר:")]
        [Range(0, 9999, ErrorMessage = " על המחיר להיות בין הערכים: 0-9999 ")]
        [Required(ErrorMessage = "זהו שדה חובה")]
        [DataType(DataType.Currency)]
        public float Price  { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "צרף קישור לתמונה")]
        public string Image { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "בחר את סוג החיה")]
        public string TypeAnimal { get; set; }


        public int CategoryId { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "בחר את קטגוריית המזון")]
        public FoodCategory Category { get; set; }

        

    }
}
