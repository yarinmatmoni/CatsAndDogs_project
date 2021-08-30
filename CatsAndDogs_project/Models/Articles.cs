using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class Articles
    {
        //public string Category { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "אורך הכותרת חייב להכיל בין 5-80 תווים")]
        [Display(Name = "כותרת")]
        public string Titel { get; set;}

        [Required(ErrorMessage = "זהו שדה חובה")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "אורך שם העורך חייב להכיל בין 3-50 תווים")]
        [Display(Name = "שם העורך")]
        public string Author { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "תאריך יצירה")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "תאריך עדכון אחרון")]
        [DataType(DataType.Date)]
        public DateTime LastUpDate { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [StringLength(2000, MinimumLength = 100, ErrorMessage = "התקציר חייב להכיל בין 100-2000 תווים")]
        [Display(Name = "תקציר")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [MinLength(200 , ErrorMessage = "גוף הכתבה חייב להכיל לפחות 200 תווים") ]
        [Display(Name = "גוף הכתבה")]
        public string Body { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "צרף קישור לתמונה")]
        public string Img { get; set; }

        [Required(ErrorMessage = "זהו שדה חובה")]
        [Display(Name = "קטגוריה")]
        public int categoryId { get; set; }

        
        public ArticalsCategory Category { get; set; }
    }
}
