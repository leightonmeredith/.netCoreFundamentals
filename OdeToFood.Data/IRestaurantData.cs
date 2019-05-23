using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1, Name="Name1", Location="Loca1", Type=CuisineType.Chinese},
                new Restaurant{Id=1, Name="Name2", Location="Loca2", Type=CuisineType.Chinese},
                new Restaurant{Id=1, Name="Name21", Location="Loca21", Type=CuisineType.Chinese}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
