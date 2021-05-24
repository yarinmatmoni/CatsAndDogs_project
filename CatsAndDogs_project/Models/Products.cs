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

        [StringLength(70, MinimumLength = 2)]
        [Display(Name = "שם המוצר")]
        [Required(ErrorMessage = "זהו שדה חובה")]
        public string Name{ get; set; }

        [StringLength(350,MinimumLength =2)]
        [Display(Name = "תיאור")]
        [Required(ErrorMessage = "זהו שדה חובה")]
        public string Description { get; set; }

        [Range(0,9999)]
        [DataType(DataType.Currency)]
        [Display(Name = "מחיר")]
        [Required(ErrorMessage ="זהו שדה חובה")]
        public float Price{ get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "צרף קישור לתמונה")]
        public String Image { get; set; }

    }
}
