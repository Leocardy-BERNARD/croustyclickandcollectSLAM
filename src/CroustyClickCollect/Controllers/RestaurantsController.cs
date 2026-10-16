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

        // TODO S2-04 (sprint 2) : indiquer pour chaque restaurant s'il est ouvert en ce moment.
        //   Consigne : pour chaque restaurant de la liste, remplir la propriété
        //              EstOuvertMaintenant grâce à HorairesService.EstOuvert(...).
        //   Indice   : une boucle foreach ; l'heure actuelle s'obtient avec DateTime.Now.TimeOfDay.

        return View(restaurants);
    }
}
