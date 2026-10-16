using CroustyClickCollect.Data;
using CroustyClickCollect.Models;
using CroustyClickCollect.Services;
using Microsoft.AspNetCore.Mvc;

namespace CroustyClickCollect.Controllers;

/// <summary>
/// Le panier (C1 à C4). Le panier est rangé dans la session du visiteur.
/// </summary>
public class PanierController : Controller
{
    private readonly ProduitRepository _produits;
    private readonly RestaurantRepository _restaurants;

    public PanierController(ProduitRepository produits, RestaurantRepository restaurants)
    {
        _produits = produits;
        _restaurants = restaurants;
    }

    // Adresse : /Panier
    public IActionResult Index()
    {
        List<LignePanier> panier = PanierSession.Lire(HttpContext.Session);
        ViewBag.Total = PanierService.CalculerTotal(panier);
        ViewBag.Restaurant = RestaurantChoisi();
        return View(panier);
    }

    // Adresse : /Panier/ChoisirRestaurant : affiche la liste des restaurants (C1).
    public IActionResult ChoisirRestaurant()
    {
        return View(_restaurants.GetTous());
    }

    // Reçoit le formulaire « Choisir ce restaurant ».
    [HttpPost]
    public IActionResult ChoisirRestaurant(int restaurantId)
    {
        PanierSession.EnregistrerRestaurant(HttpContext.Session, restaurantId);
        return RedirectToAction("Index", "Carte");
    }

    // Reçoit le formulaire « Ajouter au panier » de la carte.
    [HttpPost]
    public IActionResult Ajouter(int produitId, int? sauceId, int quantite)
    {
        // BONNE PRATIQUE (bloc 3) : le formulaire envoie seulement l'id du produit.
        // Le prix est relu dans la base : il ne vient JAMAIS du navigateur,
        // car un utilisateur peut modifier ce que son navigateur envoie.
        Produit produit = _produits.GetParId(produitId);
        if (produit == null)
        {
            TempData["Message"] = "Produit introuvable. (Le TODO S3-01 est-il fait ?)";
            return RedirectToAction("Index", "Carte");
        }

        if (quantite < 1)
        {
            quantite = 1;
        }

        List<LignePanier> panier = PanierSession.Lire(HttpContext.Session);
        if (!PanierService.PeutAjouter(panier, quantite))
        {
            TempData["Message"] = "Une commande contient au maximum " + PanierService.ArticlesMaximum + " articles.";
            return RedirectToAction("Index");
        }

        // On retrouve le nom de la sauce choisie (s'il y en a une).
        string nomSauce = "";
        foreach (Sauce sauce in _produits.GetSauces())
        {
            if (sauce.Id == sauceId)
            {
                nomSauce = sauce.Libelle;
            }
        }

        var ligne = new LignePanier
        {
            ProduitId = produit.Id,
            Libelle = produit.Libelle,
            SauceId = sauceId,
            Sauce = nomSauce,
            PrixUnitaire = produit.Prix,
            Quantite = quantite
        };
        PanierService.Ajouter(panier, ligne);
        PanierSession.Enregistrer(HttpContext.Session, panier);

        TempData["Message"] = produit.Libelle + " : ajouté au panier.";
        return RedirectToAction("Index", "Carte");
    }

    // Reçoit le formulaire « Retirer » d'une ligne du panier.
    [HttpPost]
    public IActionResult Retirer(int position)
    {
        List<LignePanier> panier = PanierSession.Lire(HttpContext.Session);
        PanierService.Retirer(panier, position);
        PanierSession.Enregistrer(HttpContext.Session, panier);
        return RedirectToAction("Index");
    }

    // Renvoie le restaurant choisi par le visiteur, ou null s'il n'en a pas choisi.
    private Restaurant RestaurantChoisi()
    {
        int? id = PanierSession.LireRestaurant(HttpContext.Session);
        if (id == null)
        {
            return null;
        }
        return _restaurants.GetParId(id.Value);
    }
}
