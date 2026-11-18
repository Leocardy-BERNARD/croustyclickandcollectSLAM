using CroustyClickCollect.Data;
using CroustyClickCollect.Models;
using CroustyClickCollect.Services;
using Microsoft.AspNetCore.Mvc;

namespace CroustyClickCollect.Controllers;

/// <summary>
/// La page « Nos restaurants » (V3).
/// </summary>
public class RestaurantsController : Controller
{
    private readonly RestaurantRepository _restaurants;

    public RestaurantsController(RestaurantRepository restaurants)
    {
        _restaurants = restaurants;
    }

    // Adresse : /Restaurants
    public IActionResult Index()
    {
        List<Restaurant> restaurants = _restaurants.GetTous();

        TimeSpan heureActuelle = DateTime.Now.TimeOfDay;

        foreach (Restaurant restaurant in restaurants)
        {
            restaurant.EstOuvertMaintenant = HorairesService.EstOuvert(
                restaurant.HeureOuverture,
                restaurant.HeureFermeture,
                heureActuelle);
        }

        return View(restaurants);
    }
}

