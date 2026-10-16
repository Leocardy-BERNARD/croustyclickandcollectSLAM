namespace CroustyClickCollect.Models;

/// <summary>
/// Un produit de la carte : plat, supplément ou boisson (table « produit »).
/// Chaque propriété correspond à une colonne de la table.
/// </summary>
public class Produit
{
    public int Id { get; set; }
    public string Libelle { get; set; }
    public string Description { get; set; }
    public string Categorie { get; set; }    // "plat", "supplement" ou "boisson"
    public decimal Prix { get; set; }        // decimal : le bon type pour de l'argent
    public string Allergenes { get; set; }
    public bool Actif { get; set; }          // false = retiré de la carte
}
