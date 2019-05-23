using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IRestaurantData _restaurantData;

        //output model property to populate w info, not receive
        public string Msg { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        //Prop should receive info from request
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this._config = config;
            this._restaurantData = restaurantData;
        }
        public void OnGet(string searchTerm)
        {
            Msg = _config["AppSettingMessage"];
            Restaurants = _restaurantData.GetRestaurantByName(SearchTerm);

        }
    }
}