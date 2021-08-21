using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class ArticalsCategory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "אורך השם חייב להכיל בין 3-25 תווים")]
        [Display(Name = "כותרת")]
        public string Name { get; set; }
        
        public List<Articles> Articles { get; set; }
    }
}
