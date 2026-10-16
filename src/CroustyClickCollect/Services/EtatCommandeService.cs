using CroustyClickCollect.Models;

namespace CroustyClickCollect.Services;

/// <summary>
/// Cycle de vie d'une commande (règle RG6) :
/// Reçue → En préparation → Prête → Retirée, toujours dans cet ordre,
/// sans jamais revenir en arrière.
/// </summary>
public static class EtatCommandeService
{
    /// <summary>
    /// Renvoie l'état qui suit l'état actuel, ou null s'il n'y a pas d'état suivant.
    /// </summary>
    public static string EtatSuivant(string etatActuel)
    {
        // TODO S5-05 (sprint 5) : donner l'état suivant d'une commande (RG6).
        //   Consigne : Reçue → En préparation → Prête → Retirée. Pour une commande
        //              Retirée ou Annulée, renvoyer null (plus rien à faire).
        //   Indice   : un switch ou une suite de if, avec les constantes de EtatCommande.
        return null;
    }
}
