namespace CroustyClickCollect.Services;

/// <summary>
/// Calcul des créneaux de retrait (règle RG3 du cahier des charges).
/// </summary>
public static class CreneauService
{
    public const int DureeCreneauMinutes = 15;        // 12:00, 12:15, 12:30…
    public const int DelaiPreparationMinutes = 20;    // temps minimum pour préparer

    /// <summary>
    /// Renvoie le début de chaque créneau de retrait encore possible aujourd'hui.
    /// Les créneaux partent de l'heure d'ouverture, toutes les 15 minutes.
    /// Exemple : restaurant ouvert de 11:30 à 23:00, il est 12:07
    ///   → 12:30, 12:45, 13:00 … 22:45 (le dernier créneau finit à 23:00).
    /// </summary>
    public static List<DateTime> CreneauxDisponibles(DateTime maintenant, TimeSpan ouverture, TimeSpan fermeture)
    {
        // TODO S4-01 (sprint 4) : calculer la liste des créneaux de retrait (RG3).
        //   Consigne : un créneau est proposé s'il commence au moins 20 minutes après
        //              « maintenant » et s'il se termine au plus tard à la fermeture.
        //   Indice   : partez de maintenant.Date + ouverture, puis avancez de 15 minutes
        //              avec une boucle while et AddMinutes(...). Les tests de
        //              CreneauServiceTests.cs donnent des exemples précis.
        return new List<DateTime>();
    }
}
