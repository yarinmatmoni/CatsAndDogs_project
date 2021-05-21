using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CatsAndDogs_project.Models;

namespace CatsAndDogs_project.Data
{
    public class CatsAndDogs_projectContext : DbContext
    {
        public CatsAndDogs_projectContext (DbContextOptions<CatsAndDogs_projectContext> options)
            : base(options)
        {
        }

        public DbSet<CatsAndDogs_project.Models.Dogs> Dogs { get; set; }
    }
}
