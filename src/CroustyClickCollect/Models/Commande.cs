namespace CroustyClickCollect.Models;

/// <summary>
/// Une commande passée sur le site (table « commande »).
/// </summary>
public class Commande
{
    public int Id { get; set; }                     // le numéro de commande
    public int RestaurantId { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime CreneauRetrait { get; set; }    // début du créneau de 15 minutes
    public string Etat { get; set; }                // voir EtatCommande.cs
    public string CodeRetrait { get; set; }         // 4 chiffres, ex. "0427"
    public string PrenomClient { get; set; }
    public string TelephoneClient { get; set; }
    public decimal Total { get; set; }

    // Les articles de la commande (remplis pour l'écran cuisine).
    public List<LigneCommande> Lignes { get; set; } = new List<LigneCommande>();
}
