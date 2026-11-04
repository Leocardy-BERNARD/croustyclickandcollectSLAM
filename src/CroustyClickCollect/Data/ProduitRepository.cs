using CroustyClickCollect.Models;
using Dapper;

namespace CroustyClickCollect.Data;

/// <summary>
/// Toutes les requêtes SQL qui concernent les produits et les sauces.
/// Règle du projet : le SQL s'écrit UNIQUEMENT dans le dossier Data.
/// </summary>
public class ProduitRepository
{
    private readonly BaseDeDonnees _bdd;

    // ASP.NET fournit automatiquement l'objet BaseDeDonnees (voir Program.cs).
    public ProduitRepository(BaseDeDonnees bdd)
    {
        _bdd = bdd;
    }

    // EXEMPLE COMPLET n°1 : compter les produits.
    // Utilisé par la page d'accueil pour vérifier que la base répond.
    public int CompterProduits()
    {
        using var connexion = _bdd.CreerConnexion();
        // ExecuteScalar renvoie UNE seule valeur (ici, un nombre).
        return connexion.ExecuteScalar<int>("SELECT COUNT(*) FROM produit");
    }

    // EXEMPLE COMPLET n°2 : lire toutes les sauces.
    public List<Sauce> GetSauces()
    {
        using var connexion = _bdd.CreerConnexion();
        // Query<Sauce> : chaque ligne du résultat devient un objet Sauce.
        // Les colonnes SQL (id, libelle) remplissent les propriétés C# (Id, Libelle).
        string sql = "SELECT id, libelle FROM sauce ORDER BY id";
        return connexion.Query<Sauce>(sql).ToList();
    }

    public List<Produit> GetTous()
    {
        using var connexion = _bdd.CreerConnexion();
        string sql = "SELECT id, libelle, Description, Categorie, Prix, Allergenes, Actif FROM produit WHERE actif = 1 ORDER BY categorie, libelle";
        return connexion.Query<Produit>(sql).ToList();
    }

    public Produit GetParId(int id)
    {
        // TODO S3-01 (sprint 3) : lire UN produit à partir de son identifiant.
        //   Consigne : renvoyer le produit dont l'id est reçu, ou null s'il n'existe pas.
        //   Indice   : regardez RestaurantRepository.GetParId(), qui fait la même chose
        //              pour un restaurant. Dans le SQL, la valeur s'écrit @id : ne collez
        //              JAMAIS la valeur dans le texte (risque d'injection SQL, voir README).
        return null;
    }
}
