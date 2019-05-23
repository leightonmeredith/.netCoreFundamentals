using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1, Name="Name1", Location="Loca1", Type=CuisineType.Chinese},
                new Restaurant{Id=1, Name="Name2", Location="Loca2", Type=CuisineType.Italian},
                new Restaurant{Id=1, Name="Name23", Location="Localuy2", Type=CuisineType.None},
                new Restaurant{Id=1, Name="Name21", Location="Loca21", Type=CuisineType.Mexican}
            };
        }
        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
