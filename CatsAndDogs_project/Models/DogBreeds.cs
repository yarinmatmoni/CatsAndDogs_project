using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class DogBreeds
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "גזע ")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "שם הגזע חייב להחיל בין 3-50 תווים")]
        public String Name { get; set; }
        
        public List<Dogs> Dogs { get; set; }
    }
}
