using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class ProductdsCategory
    {
        public int Id { get; set; }

        [StringLength(70, MinimumLength = 2)]
        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "קטגוריה")]
        public string Name { get; set; }

        public List<ProductsSubCategory> SubCategory { get; set; }
    }
}
