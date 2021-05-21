using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class Dogs
    {
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Type { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public String Size { get; set; } // big / medum / small

        [Required]
        public String Gender { get; set; }

        [Required]
        public String Color { get; set; }

        [Required]
        public String LifeExpectancy { get; set; }

        [Required]
        public String Match { get; set; } // family / apartment / children .... 

        [Required]
        public String Image { get; set; }
    }
}
