using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IRestaurantData _restaurantData;
        private readonly ILogger<ListModel> _logger;

        //output model property to populate w info, not receive
        public string Msg { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        //Prop should receive info from request
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData, ILogger<ListModel> logger)
        {
            this._config = config;
            this._restaurantData = restaurantData;
            this._logger = logger;
        }
        public void OnGet(string searchTerm)
        {
            _logger.LogError("Exec ListModel");
            Msg = _config["AppSettingMessage"];
            Restaurants = _restaurantData.GetRestaurantByName(SearchTerm);

        }
    }
}