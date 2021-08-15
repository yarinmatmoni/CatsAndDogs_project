using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class AdoptionDays
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "תאריך ושעה")]
        public DateTime DateandTime { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "מיקום")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "אורך המיקום חייב להכיל בין 10-150 תווים")]
        public string Location { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "תיאור")]
        [StringLength(250, MinimumLength = 20, ErrorMessage = "אורך התיאור חייב להכיל בין 20-250 תווים")]
        public string Discription { get; set; }
    }
}
