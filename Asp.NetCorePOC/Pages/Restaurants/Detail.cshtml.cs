using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.NetCorePOC.Data;
using Asp.NetCorePOC.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp.NetCorePOC.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantdata;

        public DetailModel(IRestaurantData restaurantdata)
        {
            this.restaurantdata = restaurantdata;
        }
        public Restaurant Restaurant { get; set; }
        [TempData]
        public string Message { get; set; }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantdata.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}