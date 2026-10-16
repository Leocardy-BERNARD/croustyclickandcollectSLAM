using CroustyClickCollect.Data;
using CroustyClickCollect.Models;
using Microsoft.AspNetCore.Mvc;

namespace CroustyClickCollect.Controllers;

/// <summary>
/// La carte des produits (V2).
/// </summary>
public class CarteController : Controller
{
    private readonly ProduitRepository _produits;

    public CarteController(ProduitRepository produits)
    {
        _produits = produits;
    }

    // Adresse : /Carte
    public IActionResult Index()
    {
        List<Produit> produits = _produits.GetTous();   // vide tant que le TODO S1-03 n'est pas fait
        ViewBag.Sauces = _produits.GetSauces();          // pour la liste déroulante des sauces
        return View(produits);                           // la liste est envoyée à Views/Carte/Index.cshtml
    }
}
