using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class FoodCategory
    {
        public int Id { get; set; }

        [Display(Name = "שם המוצר:")]
        [Required(ErrorMessage = "זהו שדה חובה")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "אורך השם חייב להחיל בין 3-50 תווים")]
        public string Name { get; set; }


        public List<Food> FoodList { get; set; }


    }
}
