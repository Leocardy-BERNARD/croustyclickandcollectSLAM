namespace CroustyClickCollect.Models;

/// <summary>
/// Un article du panier. Le panier est une List&lt;LignePanier&gt; gardée dans
/// la session du visiteur (voir Services/PanierSession.cs).
/// Exemple : 2 × « Crousty classique » avec « Sauce maison » à 9,00 €.
/// </summary>
public class LignePanier
{
    public int ProduitId { get; set; }
    public string Libelle { get; set; }
    public int? SauceId { get; set; }        // int? = un nombre OU rien (null = sans sauce)
    public string Sauce { get; set; }        // nom de la sauce, pour l'affichage
    public decimal PrixUnitaire { get; set; }
    public int Quantite { get; set; }
}
