using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class Breed_2
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "גזע")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "שם הגזע חייב להחיל בין 3-50 תווים")]
        public string Name { get; set; }

        public List<Dog_2> ListDog { get; set; }
    }
}
