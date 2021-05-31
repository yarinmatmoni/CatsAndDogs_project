using CatsAndDogs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class ProductsSubCategory
    {
        public int Id { get; set; }

        [StringLength(70, MinimumLength = 2)]
        [Display(Name = "קטגוריה")]
        [Required(ErrorMessage = "שדה זה חובה")]

        public string Name { get; set; }

        public List<Products> ProductsList { get; set; }
    }
}
