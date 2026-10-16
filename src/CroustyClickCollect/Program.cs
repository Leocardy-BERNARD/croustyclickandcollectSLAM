// =====================================================================
//  Program.cs : le point de départ du site.
//  Ce fichier est déjà prêt : vous n'avez rien à y modifier pendant les
//  premiers sprints. Lisez-le pour comprendre comment le site démarre.
// =====================================================================

using System.Globalization;
using CroustyClickCollect.Data;
using CroustyClickCollect.Outils;
using CroustyClickCollect.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

// 1. On lit le fichier .env (adresse de la base, mot de passe…).
//    BONNE PRATIQUE (bloc 3) : les secrets ne sont jamais écrits dans le code.
FichierEnv.Charger();

// Les prix et les dates s'affichent « à la française » : 9,00 € et 18/11/2026.
var francais = new CultureInfo("fr-FR");
CultureInfo.DefaultThreadCurrentCulture = francais;
CultureInfo.DefaultThreadCurrentUICulture = francais;

var builder = WebApplication.CreateBuilder(args);

// 2. On déclare ce dont le site a besoin.
builder.Services.AddControllersWithViews(options =>
{
    // BONNE PRATIQUE (bloc 3, SEC5) : chaque formulaire envoyé en POST est
    // protégé contre l'attaque CSRF (un autre site qui enverrait un formulaire
    // à votre place). Les formulaires Razor ajoutent le jeton tout seuls.
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

// Le panier est gardé dans la « session » : une petite mémoire propre à chaque visiteur.
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);   // le panier est oublié après 30 min sans activité
    options.Cookie.HttpOnly = true;                    // le JavaScript de la page ne peut pas lire ce cookie
    options.Cookie.IsEssential = true;
});

// Connexion du personnel (sprint 5) : la personne connectée est mémorisée dans un cookie.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Compte/Connexion";   // page affichée si on n'est pas connecté
        options.Cookie.HttpOnly = true;
    });

// Nos propres classes. ASP.NET les crée lui-même et les donne aux controllers
// qui les demandent dans leur constructeur (on appelle ça l'« injection »).
builder.Services.AddSingleton<BaseDeDonnees>();
builder.Services.AddScoped<ProduitRepository>();
builder.Services.AddScoped<RestaurantRepository>();
builder.Services.AddScoped<CommandeRepository>();
builder.Services.AddScoped<PersonnelRepository>();
builder.Services.AddScoped<CommandeService>();

// Dapper : la colonne SQL « heure_ouverture » remplira la propriété C# « HeureOuverture ».
Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

var app = builder.Build();

// 3. On règle le traitement de chaque demande.
if (!app.Environment.IsDevelopment())
{
    // BONNE PRATIQUE (bloc 3) : en production, on n'affiche jamais le détail
    // d'une erreur aux visiteurs (il pourrait aider un pirate). En développement,
    // ASP.NET affiche une page détaillée pour vous aider à corriger.
    app.UseExceptionHandler("/Home/Erreur");
}

app.UseStaticFiles();        // fichiers du dossier wwwroot (CSS, JavaScript)
app.UseRouting();
app.UseSession();
app.UseAuthentication();     // qui est connecté ?
app.UseAuthorization();      // a-t-il le droit de voir cette page ?

// L'adresse /Carte/Index appelle la méthode Index() de CarteController.
// Sans rien après le nom de domaine, c'est HomeController.Index() qui répond.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
