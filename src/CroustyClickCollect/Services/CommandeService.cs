using CroustyClickCollect.Data;
using CroustyClickCollect.Models;

namespace CroustyClickCollect.Services;

/// <summary>
/// Validation d'une commande (sprint 4). Ce service a besoin de la base :
/// il reçoit donc les repositories dans son constructeur.
/// </summary>
public class CommandeService
{
    private readonly ProduitRepository _produits;
    private readonly CommandeRepository _commandes;

    public CommandeService(ProduitRepository produits, CommandeRepository commandes)
    {
        _produits = produits;
        _commandes = commandes;
    }

    public static string GenererCodeRetrait()
    {
        // TODO S4-02 (sprint 4) : fabriquer le code de retrait (RG8).
        //   Consigne : renvoyer un code de 4 chiffres tiré au hasard, sous forme de texte.
        //   Indice   : Random.Shared.Next(min, max) donne un nombre au hasard (max exclu).
        //              Attention : le code « 0042 » doit garder ses zéros devant.
        return "0000";
    }

    /// <summary>
    /// Valide le panier : prix recalculés, total, enregistrement en base.
    /// Renvoie la commande enregistrée, ou null si un produit n'est plus disponible.
    /// </summary>
    public Commande Valider(List<LignePanier> panier, int restaurantId, DateTime creneau,
                            string prenom, string telephone)
    {
        // TODO S4-03 (sprint 4) : recalculer les prix côté serveur (RG5).
        //   Consigne : pour chaque ligne du panier, relire le produit dans la base et
        //              remplacer ligne.PrixUnitaire par le prix de la base. Si le produit
        //              n'existe plus ou n'est plus actif, renvoyer null.
        //   Indice   : une boucle foreach et _produits.GetParId(...).
        //   Pourquoi : le prix a pu changer depuis l'ajout au panier ; on ne fait
        //              confiance qu'à la base (voir README > Bonnes pratiques).

        var commande = new Commande
        {
            RestaurantId = restaurantId,
            DateCreation = DateTime.Now,
            CreneauRetrait = creneau,
            Etat = EtatCommande.Recue,
            CodeRetrait = GenererCodeRetrait(),
            PrenomClient = prenom,
            TelephoneClient = telephone,
            Total = PanierService.CalculerTotal(panier)
        };
        commande.Id = _commandes.Enregistrer(commande, panier);
        return commande;
    }
}
