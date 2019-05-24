using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1, Name="Name1", Location="Loca1", Type=CuisineType.Chinese},
                new Restaurant{Id=2, Name="Name2", Location="Loca2", Type=CuisineType.Italian},
                new Restaurant{Id=3, Name="Name23", Location="Localuy2", Type=CuisineType.None},
                new Restaurant{Id=4, Name="Name21", Location="Loca21", Type=CuisineType.Mexican}
            };
        }
        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Type = updatedRestaurant.Type;
            }
            return restaurant;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            //var newRestaurant = new Restaurant();
            restaurants.Add(newRestaurant);

            //Only use in test/dev. Id is generated automatically on db
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public int Commit()
        {
            //doesn't mean much until we have a datasource
            return 0;
        }
    }
}
