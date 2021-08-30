using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class BreedCat_2
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "שם")]
        public string Name { get; set; }

        public List<Cat_2> CatList { get; set; }

        public GuideCat GuideCat { get; set; }
    }
}
