using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public int OriginalItemId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public int Anount { get; set; }

        public string Image { get; set; }

        public string Category { get; set; }

    }
}
