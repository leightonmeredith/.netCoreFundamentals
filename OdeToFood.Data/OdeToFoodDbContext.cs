using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext: DbContext
    {
        //options 4wd to DbContext base class; nothing to do with it here
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options)
            : base(options)
        {
            //takes connection options and provider options
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
