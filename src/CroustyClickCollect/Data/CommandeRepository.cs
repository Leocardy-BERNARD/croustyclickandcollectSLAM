using CroustyClickCollect.Models;
using Dapper;

namespace CroustyClickCollect.Data;

/// <summary>
/// Toutes les requêtes SQL qui concernent les commandes.
/// </summary>
public class CommandeRepository
{
    private readonly BaseDeDonnees _bdd;

    public CommandeRepository(BaseDeDonnees bdd)
    {
        _bdd = bdd;
    }

    /// <summary>
    /// Enregistre la commande et ses lignes. Renvoie le numéro (id) de la commande créée.
    /// </summary>
    public int Enregistrer(Commande commande, List<LignePanier> lignes)
    {
        // TODO S4-04 (sprint 4) : enregistrer la commande et ses lignes dans la base.
        //   Consigne : 1) ajouter la commande dans la table « commande » et récupérer
        //                 son numéro ; 2) ajouter chaque ligne dans « ligne_commande »
        //                 avec ce numéro ; 3) renvoyer le numéro.
        //   Indice   : requêtes INSERT paramétrées (@RestaurantId, @Etat…). Écrivez
        //              « INSERT … ; SELECT LAST_INSERT_ID(); » dans la MÊME requête et lisez
        //              le numéro créé avec ExecuteScalar<int>(sql, commande). Pour les lignes :
        //              une boucle foreach et connexion.Execute(sql, new { ... }).
        return 0;
    }

    // EXEMPLE COMPLET : lire une commande à partir de son numéro.
    public Commande GetParId(int id)
    {
        using var connexion = _bdd.CreerConnexion();
        string sql = "SELECT * FROM commande WHERE id = @id";
        return connexion.QuerySingleOrDefault<Commande>(sql, new { id = id });
    }

    // EXEMPLE COMPLET : lire les articles d'une commande, avec une JOINTURE.
    // LEFT JOIN sur la sauce : la ligne est gardée même s'il n'y a pas de sauce.
    // « AS produit » renomme la colonne pour qu'elle remplisse la propriété Produit.
    public List<LigneCommande> GetLignes(int commandeId)
    {
        using var connexion = _bdd.CreerConnexion();
        string sql = @"SELECT p.libelle AS produit, s.libelle AS sauce,
                              l.quantite, l.prix_unitaire
                       FROM ligne_commande l
                       JOIN produit p ON p.id = l.produit_id
                       LEFT JOIN sauce s ON s.id = l.sauce_id
                       WHERE l.commande_id = @commandeId
                       ORDER BY l.id";
        return connexion.Query<LigneCommande>(sql, new { commandeId = commandeId }).ToList();
    }

    public List<Commande> GetDuJour(int restaurantId)
    {
        // TODO S5-03 (sprint 5) : lire les commandes du jour d'un restaurant (écran cuisine).
        //   Consigne : commandes du restaurant reçu, dont le créneau de retrait est
        //              aujourd'hui, triées par créneau (la plus proche en premier).
        //   Indice   : en SQL, DATE(creneau_retrait) = CURDATE() garde « aujourd'hui ».
        return new List<Commande>();
    }

    public void ChangerEtat(int commandeId, string nouvelEtat)
    {
        // TODO S5-06 (sprint 5) : enregistrer le nouvel état d'une commande.
        //   Consigne : modifier la colonne « etat » de la commande reçue.
        //   Indice   : une requête UPDATE paramétrée, exécutée avec connexion.Execute(sql, ...).
    }

    /// <summary>
    /// Renvoie l'état de la commande, ou null si le numéro ou le code de retrait est faux.
    /// </summary>
    public string GetEtat(int commandeId, string codeRetrait)
    {
        // TODO S6-01 (sprint 6) : lire l'état d'une commande, seulement si le code est bon.
        //   Consigne : renvoyer la colonne « etat » de la commande dont l'id ET le code
        //              de retrait correspondent ; null sinon.
        //   Indice   : WHERE avec deux conditions ; QuerySingleOrDefault<string>.
        return null;
    }
}
