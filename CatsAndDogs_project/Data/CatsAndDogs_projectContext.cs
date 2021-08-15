using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CatsAndDogs_project.Models;
using CatsAndDogs.Models;

namespace CatsAndDogs_project.Data
{
    public class CatsAndDogs_projectContext : DbContext
    {
        public CatsAndDogs_projectContext (DbContextOptions<CatsAndDogs_projectContext> options)
            : base(options)
        {
        }

        public DbSet<CatsAndDogs_project.Models.Dogs> Dogs { get; set; }

        public DbSet<CatsAndDogs_project.Models.Cats> Cats { get; set; }

        public DbSet<CatsAndDogs.Models.Products> Products { get; set; }

        public DbSet<CatsAndDogs_project.Models.DogBreeds> DogBreeds { get; set; }

        public DbSet<CatsAndDogs_project.Models.ProductsSubCategory> ProductsSubCategory { get; set; }

        public DbSet<CatsAndDogs_project.Models.AdoptionDays> AdoptionDays { get; set; }
    }
}
