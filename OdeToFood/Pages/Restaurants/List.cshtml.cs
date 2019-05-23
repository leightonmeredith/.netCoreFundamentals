using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;

        public string Msg { get; set; }

        public ListModel(IConfiguration config)
        {
            this._config = config;
        }
        public void OnGet()
        {
            Msg = _config["AppSettingMessage"]; //"Hello World";
        }
    }
}