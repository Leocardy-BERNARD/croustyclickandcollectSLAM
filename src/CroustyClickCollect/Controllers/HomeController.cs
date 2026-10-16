using CroustyClickCollect.Data;
using Microsoft.AspNetCore.Mvc;

namespace CroustyClickCollect.Controllers;

/// <summary>
/// Pages générales : accueil, pages légales, page d'erreur.
/// Un controller reçoit la demande du navigateur, prépare les données,
/// puis choisit la vue (la page Razor) à afficher.
/// </summary>
public class HomeController : Controller
{
    private readonly ProduitRepository _produits;
    private readonly IWebHostEnvironment _environnement;

    // ASP.NET fournit ces objets automatiquement (voir Program.cs).
    public HomeController(ProduitRepository produits, IWebHostEnvironment environnement)
    {
        _produits = produits;
        _environnement = environnement;
    }

    // Adresse : /  (ou /Home/Index)
    public IActionResult Index()
    {
        // Vérification de l'installation : on essaie de lire la base.
        try
        {
            ViewBag.NombreProduits = _produits.CompterProduits();
            ViewBag.BaseOk = true;
        }
        catch (Exception erreur)
        {
            ViewBag.BaseOk = false;
            // BONNE PRATIQUE (bloc 3) : le message technique n'est montré qu'en
            // développement. En production, il pourrait renseigner un pirate.
            if (_environnement.IsDevelopment())
            {
                ViewBag.MessageErreur = erreur.Message;
            }
        }
        return View();
    }

    // Adresse : /Home/MentionsLegales
    public IActionResult MentionsLegales()
    {
        return View();
    }

    // Adresse : /Home/Confidentialite
    public IActionResult Confidentialite()
    {
        return View();
    }

    // Adresse : /Home/Cgv
    public IActionResult Cgv()
    {
        return View();
    }

    // Page affichée en production quand une erreur se produit (voir Program.cs).
    public IActionResult Erreur()
    {
        return View();
    }
}
