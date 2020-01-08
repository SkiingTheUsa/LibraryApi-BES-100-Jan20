using Microsoft.AspNetCore.Mvc;
using System;

namespace LibraryApi.Controllers
{
    public class MenuController : Controller
    {
        // GET /Maragaritas

        [HttpGet("/margaritas")]
        public IActionResult OrderMargaritas()
        {
            var response = new MenuModel
            {
                Description = "Delicious Margarita",
                Price = 8.99m,
                PriceGoodUntil = DateTime.Now.AddDays(5)
            };

            return Ok(response);
        }

    }


}

public class MenuModel
{
    public string Description { get; set; }
    public decimal Price { get; set; }

    public DateTime PriceGoodUntil { get; set; }
}

