using CatsAndDogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class ProdectsSubCategory
    { 
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Products> ProductsList { get; set; }
    }
}
