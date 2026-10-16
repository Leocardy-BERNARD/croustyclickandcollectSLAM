namespace CroustyClickCollect.Services;

/// <summary>
/// Règles liées aux horaires des restaurants.
/// Un « service » contient les RÈGLES MÉTIER : pas de SQL, pas de HTML.
/// C'est ce qui permet de les tester facilement (voir le dossier tests/).
/// </summary>
public static class HorairesService
{
    /// <summary>
    /// Indique si un restaurant est ouvert à une heure donnée.
    /// Exemple : ouvert de 11:30 à 23:00 → ouvert à 11:30 et à 22:59,
    /// fermé à 11:29 et à 23:00.
    /// </summary>
    public static bool EstOuvert(TimeSpan ouverture, TimeSpan fermeture, TimeSpan heure)
    {
        // TODO S2-02 (sprint 2) : écrire la règle d'ouverture.
        //   Consigne : renvoyer true si « heure » est comprise entre l'ouverture (incluse)
        //              et la fermeture (exclue), false sinon.
        //   Indice   : deux TimeSpan se comparent avec <, <=, >, >= comme des nombres.
        //              Les tests de tests/.../HorairesServiceTests.cs vous diront si c'est juste.
        return false;
    }
}
