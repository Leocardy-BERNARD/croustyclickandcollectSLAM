using System.Security.Claims;
using CroustyClickCollect.Data;
using CroustyClickCollect.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;   // contient PasswordHasher (TODO S5-02)
using Microsoft.AspNetCore.Mvc;

namespace CroustyClickCollect.Controllers;

/// <summary>
/// Connexion et déconnexion du personnel (K1).
/// </summary>
public class CompteController : Controller
{
    private readonly PersonnelRepository _personnel;

    public CompteController(PersonnelRepository personnel)
    {
        _personnel = personnel;
    }

    // Adresse : /Compte/Connexion : affiche le formulaire.
    public IActionResult Connexion()
    {
        return View();
    }

    // Reçoit le formulaire de connexion.
    // « async » et « await » : on attend que le cookie de connexion soit créé.
    [HttpPost]
    public async Task<IActionResult> Connexion(string identifiant, string motDePasse)
    {
        Personnel personne = _personnel.GetParIdentifiant(identifiant);
        bool motDePasseCorrect = false;

        // TODO S5-02 (sprint 5) : vérifier le mot de passe (SEC2).
        //   Consigne : si la personne existe, comparer le mot de passe tapé avec
        //              l'empreinte enregistrée (personne.MotDePasseHash) et mettre
        //              le résultat dans motDePasseCorrect.
        //   Indice   : un objet new PasswordHasher<Personnel>() possède une méthode
        //              VerifyHashedPassword(...). Le mot de passe est bon si le résultat
        //              est différent de PasswordVerificationResult.Failed. Un mot de passe
        //              vide est toujours faux : vérifiez-le avant (string.IsNullOrEmpty).

        if (personne == null || !motDePasseCorrect)
        {
            // BONNE PRATIQUE (bloc 3) : on ne dit pas si c'est l'identifiant ou le mot de
            // passe qui est faux. Sinon, un pirate saurait quels identifiants existent.
            ViewBag.Erreur = "Identifiant ou mot de passe incorrect.";
            return View();
        }

        // La personne est reconnue : on lui donne un « badge » (cookie de connexion)
        // qui contient son prénom, son rôle et l'id de son restaurant.
        var informations = new List<Claim>
        {
            new Claim(ClaimTypes.Name, personne.Prenom),
            new Claim(ClaimTypes.Role, personne.Role),
            new Claim("RestaurantId", personne.RestaurantId.ToString())
        };
        var identite = new ClaimsIdentity(informations, CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                      new ClaimsPrincipal(identite));

        return RedirectToAction("Index", "Cuisine");
    }

    // Reçoit le bouton « Se déconnecter ».
    [HttpPost]
    public async Task<IActionResult> Deconnexion()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}
