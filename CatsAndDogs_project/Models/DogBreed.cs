using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAndDogs_project.Models
{
    public class DogBreed
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public List<Dogs> Dogs { get; set; }
    }
}
