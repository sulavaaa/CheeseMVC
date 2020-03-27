using CheeseMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Data
{
    public class CheeseDbContext: DbContext
    {
        public CheeseDbContext(DbContextOptions<CheeseDbContext> options)
            :base(options)
        {

        }

        public DbSet<Cheese> Cheeses { get; set; }
        public DbSet<CheeseCategory> Categories { get; set; }
    }
}
