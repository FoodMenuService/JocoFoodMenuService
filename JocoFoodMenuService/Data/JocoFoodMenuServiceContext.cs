using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JocoFoodMenuService.Models;

namespace JocoFoodMenuService.Data
{
    public class JocoFoodMenuServiceContext : DbContext
    {
        public JocoFoodMenuServiceContext (DbContextOptions<JocoFoodMenuServiceContext> options)
            : base(options)
        {
        }

        public DbSet<JocoFoodMenuService.Models.Beverage> Beverage { get; set; }

        public DbSet<JocoFoodMenuService.Models.Complement> Complement { get; set; }

        public DbSet<JocoFoodMenuService.Models.Grain> Grain { get; set; }

        public DbSet<JocoFoodMenuService.Models.Meat> Meat { get; set; }

        public DbSet<JocoFoodMenuService.Models.Rice> Rice { get; set; }

        public DbSet<JocoFoodMenuService.Models.MenuCreator> MenuCreator { get; set; }
    }
}
