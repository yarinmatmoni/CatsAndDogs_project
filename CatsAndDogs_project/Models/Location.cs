using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class Location
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "תיאור המיקום")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "אורך התיאור חייב להכיל בין 10-80 תווים")]
        public string Discription { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "ציר ה-X")]
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "יכול להכיל אך ורק מספרים ")]
        public double CordX { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "ציר ה-Y")]
        [RegularExpression(@"^[0-9.]*$", ErrorMessage = "יכול להכיל אך ורק מספרים ")]
        public double CordY { get; set; }

    }
}
