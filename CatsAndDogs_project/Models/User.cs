using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs.Models
{ 
    public class User
    {
        public enum UserType
        {
            Admin = 1,
            Editor, //2
            Client //3
        }

        [Key]
        [Display(Name = "שם משתמש")]
        [Required(ErrorMessage = "זהו שדה חובה")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "אורך שם המשתמש חייב להכיל בין 8-30 תווים")]
        public string UserName { get; set; }

        [Display(Name = "סיסמא")]
        [Required(ErrorMessage = "זהו שדה חובה")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "הסיסמא חייבת להכיל לפחות 8 תווים,אות קטנה,אות גדולה וספרה אחת")]
        public string Password { get; set; }

        //[Display(Name = "שם פרטי")]
        //[Required(ErrorMessage = "זהו שדה חובה")]
        //[RegularExpression(@"^[a-z\u05D0-\u05EA ']+$", ErrorMessage = "השם הפרטי יכול להכיל אך ורק אותיות")]
        //[StringLength(20, MinimumLength = 2, ErrorMessage = "אורך השם הפרטי חייב להיות בין 2-20 תווים")]
        //public string FirstName { get; set; }

        //[Display(Name = "שם משפחה")]
        //[Required(ErrorMessage = "זהו שדה חובה")]
        //[RegularExpression(@"^[a-z\u05D0-\u05EA ']+$", ErrorMessage = "שם המשפחה יכול להכיל אך ורק אותיות")]
        //[StringLength(30, MinimumLength = 2, ErrorMessage = "אורך שם המשפחה חייב להיות בין 2-30 תווים")]
        //public string SecondName { get; set; }

        public UserType Usertype { get; set; } = UserType.Client;

    }
}
