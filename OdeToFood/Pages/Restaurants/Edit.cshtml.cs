using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty] //changed to input AND output
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue)
            {

                Restaurant = _restaurantData.GetById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>(); //must add because .net is stateless


                return Page();
            }

            if (Restaurant.Id > 0)
            {

                Restaurant = _restaurantData.Update(Restaurant);
            }
            else
            {
                Restaurant = _restaurantData.Add(Restaurant);
            }
            _restaurantData.Commit();

            //temp data goes away so no need to clean up. 
            //On next request any page can get this message
            //...unless it's in cshtml
            TempData["Message"] = "Restaurant saved!"; 

            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}