namespace CroustyClickCollect.Models;

/// <summary>
/// Un membre du personnel d'un restaurant (table « personnel »).
/// </summary>
public class Personnel
{
    public int Id { get; set; }
    public string Identifiant { get; set; }
    public string MotDePasseHash { get; set; }   // l'empreinte du mot de passe, jamais le mot de passe
    public string Prenom { get; set; }
    public string Nom { get; set; }
    public string Role { get; set; }             // "equipier" ou "gerant"
    public int RestaurantId { get; set; }
}
