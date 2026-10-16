using CroustyClickCollect.Data;
using CroustyClickCollect.Models;
using CroustyClickCollect.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CroustyClickCollect.Controllers;

/// <summary>
/// L'écran cuisine (K2, K3), réservé au personnel connecté.
/// </summary>
// BONNE PRATIQUE (bloc 3, SEC3) : [Authorize] bloque toutes les pages de ce
// controller pour les visiteurs non connectés (ils sont renvoyés vers la page
// de connexion). Masquer un lien ne suffit pas : on peut taper l'adresse à la main.
[Authorize]
public class CuisineController : Controller
{
    private readonly CommandeRepository _commandes;

    public CuisineController(CommandeRepository commandes)
    {
        _commandes = commandes;
    }

    // Adresse : /Cuisine : les commandes du jour du restaurant de la personne connectée.
    public IActionResult Index()
    {
        int restaurantId = RestaurantDeLaPersonneConnectee();
        List<Commande> commandes = _commandes.GetDuJour(restaurantId);
        foreach (Commande commande in commandes)
        {
            commande.Lignes = _commandes.GetLignes(commande.Id);
        }
        return View(commandes);
    }

    // Reçoit le bouton « Étape suivante » d'une commande.
    [HttpPost]
    public IActionResult AvancerEtat(int id)
    {
        // TODO S5-07 (sprint 5) : faire avancer l'état d'une commande (K3, RG6, RG10).
        //   Consigne : 1) lire la commande ; 2) si elle n'existe pas ou si elle appartient
        //              à un autre restaurant que celui de la personne connectée,
        //              renvoyer NotFound() ; 3) sinon, calculer l'état suivant et l'enregistrer
        //              (s'il n'y a pas d'état suivant, ne rien changer).
        //   Indice   : _commandes.GetParId(...), RestaurantDeLaPersonneConnectee(),
        //              EtatCommandeService.EtatSuivant(...), _commandes.ChangerEtat(...).

        return RedirectToAction("Index");
    }

    // Renvoie l'id du restaurant de la personne connectée.
    private int RestaurantDeLaPersonneConnectee()
    {
        // TODO S5-04 (sprint 5) : lire le restaurant de la personne connectée (RG10).
        //   Consigne : renvoyer la valeur « RestaurantId » rangée dans le badge de connexion
        //              (voir CompteController). Ne JAMAIS la prendre dans l'adresse de la page :
        //              n'importe qui pourrait la changer pour voir les commandes d'un autre restaurant.
        //   Indice   : User.FindFirst("RestaurantId").Value donne un texte ; int.Parse(...)
        //              le transforme en nombre.
        return 0;
    }
}
