namespace CroustyClickCollect.Models;

/// <summary>
/// Les états possibles d'une commande (règle RG6 du cahier des charges).
/// Reçue → En préparation → Prête → Retirée. Annulée est possible à part.
///
/// On utilise ces constantes au lieu d'écrire le texte à la main partout :
/// une faute de frappe (« Recue » au lieu de « Reçue ») serait invisible
/// et casserait le site. Avec EtatCommande.Recue, le compilateur vérifie.
/// </summary>
public static class EtatCommande
{
    public const string Recue = "Reçue";
    public const string EnPreparation = "En préparation";
    public const string Prete = "Prête";
    public const string Retiree = "Retirée";
    public const string Annulee = "Annulée";
}
