using CroustyClickCollect.Data;
using CroustyClickCollect.Models;
using CroustyClickCollect.Services;
using Microsoft.AspNetCore.Mvc;

namespace CroustyClickCollect.Controllers;

/// <summary>
/// Validation de la commande (C5, C6) et suivi de son état (C7).
/// </summary>
public class CommandeController : Controller
{
    private readonly RestaurantRepository _restaurants;
    private readonly CommandeRepository _commandes;
    private readonly CommandeService _service;

    public CommandeController(RestaurantRepository restaurants, CommandeRepository commandes,
                              CommandeService service)
    {
        _restaurants = restaurants;
        _commandes = commandes;
        _service = service;
    }

    // Adresse : /Commande/Valider : affiche le formulaire (créneau, prénom, téléphone).
    public IActionResult Valider()
    {
        List<LignePanier> panier = PanierSession.Lire(HttpContext.Session);
        if (panier.Count == 0)
        {
            return RedirectToAction("Index", "Panier");
        }

        Restaurant restaurant = RestaurantDuVisiteur();
        if (restaurant == null)
        {
            TempData["Message"] = "Choisissez d'abord le restaurant où vous viendrez chercher votre commande.";
            return RedirectToAction("ChoisirRestaurant", "Panier");
        }

        return AfficherFormulaire(panier, restaurant);
    }

    // Reçoit le formulaire de validation.
    [HttpPost]
    public IActionResult Valider(string prenom, string telephone, DateTime creneau)
    {
        List<LignePanier> panier = PanierSession.Lire(HttpContext.Session);
        Restaurant restaurant = RestaurantDuVisiteur();
        if (panier.Count == 0 || restaurant == null)
        {
            return RedirectToAction("Index", "Panier");
        }

        // TODO S4-05 (sprint 4) : vérifier ce que le formulaire a envoyé (SEC4).
        //   Consigne : si le prénom ou le téléphone est vide, ou si le créneau ne fait pas
        //              partie des créneaux disponibles, mettre un message dans ViewBag.Erreur
        //              et réafficher le formulaire au lieu d'enregistrer la commande.
        //   Indice   : string.IsNullOrWhiteSpace(...) ; la liste des créneaux se calcule
        //              comme dans AfficherFormulaire(), et .Contains(creneau) dit si le
        //              créneau en fait partie. Pour réafficher : return AfficherFormulaire(...);

        Commande commande = _service.Valider(panier, restaurant.Id, creneau, prenom, telephone);
        if (commande == null)
        {
            ViewBag.Erreur = "Un produit de votre panier n'est plus disponible. Modifiez votre panier.";
            return AfficherFormulaire(panier, restaurant);
        }

        PanierSession.Vider(HttpContext.Session);
        TempData["Numero"] = commande.Id;
        TempData["Code"] = commande.CodeRetrait;
        return RedirectToAction("Confirmation");
    }

    // Adresse : /Commande/Confirmation : récapitulatif après validation.
    public IActionResult Confirmation()
    {
        if (TempData["Numero"] == null)
        {
            return RedirectToAction("Index", "Home");
        }
        ViewBag.Numero = TempData["Numero"];
        ViewBag.Code = TempData["Code"];
        return View();
    }

    // Adresse : /Commande/Suivi?id=12&code=0427 : page de suivi pour le client.
    public IActionResult Suivi(int id, string code)
    {
        ViewBag.Numero = id;
        ViewBag.Code = code;
        ViewBag.Etat = _commandes.GetEtat(id, code);   // null tant que le TODO S6-01 n'est pas fait
        return View();
    }

    // Adresse : /Commande/Etat?id=12&code=0427
    // Ne renvoie pas une page, mais des données JSON, lues par wwwroot/js/suivi.js.
    public IActionResult Etat(int id, string code)
    {
        // TODO S6-02 (sprint 6) : renvoyer l'état de la commande au format JSON (C7).
        //   Consigne : lire l'état avec _commandes.GetEtat(...). S'il est null (commande
        //              inconnue ou mauvais code), renvoyer NotFound(). Sinon, renvoyer un
        //              objet JSON de la forme { "etat": "Prête" }.
        //   Indice   : return Json(new { etat = ... });
        return NotFound();
    }

    // Prépare et affiche le formulaire de validation.
    private IActionResult AfficherFormulaire(List<LignePanier> panier, Restaurant restaurant)
    {
        ViewBag.Restaurant = restaurant;
        ViewBag.Total = PanierService.CalculerTotal(panier);
        ViewBag.Creneaux = CreneauService.CreneauxDisponibles(DateTime.Now,
                                                               restaurant.HeureOuverture,
                                                               restaurant.HeureFermeture);
        return View("Valider", panier);
    }

    private Restaurant RestaurantDuVisiteur()
    {
        int? id = PanierSession.LireRestaurant(HttpContext.Session);
        if (id == null)
        {
            return null;
        }
        return _restaurants.GetParId(id.Value);
    }
}
