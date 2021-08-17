using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class CareCategory
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "שם ")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "אורך השם חייב להכיל בין 3-50 תווים")]
        public string Name { get; set; }

        public List<Care> CareList { get; set; }
    }
}
