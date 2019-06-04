using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        //dotnet ef migrations add initCreate -s ..\OdeToFood\OdeToFood.csproj
        //dotnet ef dbcontext info -s ..\OdeToFood\OdeToFood.csproj
        //dotnet ef migrations script -s ..\OdeToFood\OdeToFood.csproj

        //options 4wd to DbContext base class; nothing to do with it here
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options)
            : base(options)
        {
            //takes connection options and provider options
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
