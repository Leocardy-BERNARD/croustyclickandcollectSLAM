namespace CroustyClickCollect.Models;

/// <summary>
/// Un article d'une commande, tel qu'il s'affiche en cuisine.
/// Rempli par CommandeRepository.GetLignes().
/// </summary>
public class LigneCommande
{
    public string Produit { get; set; }      // nom du produit
    public string Sauce { get; set; }        // nom de la sauce (vide = sans sauce)
    public int Quantite { get; set; }
    public decimal PrixUnitaire { get; set; }
}
