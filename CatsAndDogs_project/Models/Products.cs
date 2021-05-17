using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs.Models
{
    public class Products
    {
        public int Id { get; set; }

        [StringLength(70, MinimumLength = 5)]
        [Required(ErrorMessage = "You have to wrire the name of the product")]
        public string Name{ get; set; }

        [StringLength(350,MinimumLength =10)] 
        [Required(ErrorMessage = "You have to wrire description (10-350 Characters)")]
        public string Description { get; set; }

        [Range(0,9999)]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You have to type a price")]
        public float Price{ get; set; }

        
    }
}
