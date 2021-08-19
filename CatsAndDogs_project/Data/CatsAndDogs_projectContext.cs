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


        public DbSet<CatsAndDogs_project.Models.DogBreeds> DogBreeds { get; set; }


        public DbSet<CatsAndDogs_project.Models.AdoptionDays> AdoptionDays { get; set; }


        public DbSet<CatsAndDogs_project.Models.Health> Health { get; set; }


        public DbSet<CatsAndDogs_project.Models.HealthCategory> HealthCategory { get; set; }


        public DbSet<CatsAndDogs_project.Models.Care> Care { get; set; }


        public DbSet<CatsAndDogs_project.Models.CareCategory> CareCategory { get; set; }


        public DbSet<CatsAndDogs_project.Models.Accessories> Accessories { get; set; }


        public DbSet<CatsAndDogs_project.Models.AccessoriesCategory> AccessoriesCategory { get; set; }


        public DbSet<CatsAndDogs_project.Models.SleepAndEnvironment> SleepAndEnvironment { get; set; }


        public DbSet<CatsAndDogs_project.Models.SleepAndEnvironmentCategory> SleepAndEnvironmentCategory { get; set; }


        public DbSet<CatsAndDogs_project.Models.Nutrition> Nutrition { get; set; }


        public DbSet<CatsAndDogs_project.Models.NutritionCategory> NutritionCategory { get; set; }


        public DbSet<CatsAndDogs_project.Models.Dog_2> Dog_2 { get; set; }


        public DbSet<CatsAndDogs_project.Models.Breed_2> Breed_2 { get; set; }
        
    }
}
