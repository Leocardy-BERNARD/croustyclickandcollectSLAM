using CroustyClickCollect.Services;

namespace CroustyClickCollect.Tests;

/// <summary>
/// Tests des créneaux de retrait (RG3) et du code de retrait (RG8), sprint 4.
/// </summary>
public class CommandeTests
{
    private static readonly TimeSpan Ouverture = new TimeSpan(11, 30, 0);
    private static readonly TimeSpan Fermeture = new TimeSpan(23, 0, 0);

    // Mercredi 18 novembre 2026, à l'heure indiquée.
    private static DateTime Le18Novembre(int heure, int minute)
    {
        return new DateTime(2026, 11, 18, heure, minute, 0);
    }

    // TODO S4-06 (sprint 4) : activer les tests de la commande.
    //   Consigne : quand les TODO S4-01 et S4-02 sont faits, retirez « (Skip = "...") »
    //              de chaque test ci-dessous, puis lancez « dotnet test ».
    //   Indice   : si un test échoue, relisez son nom : il dit la situation et le résultat attendu.

    [Fact(Skip = "Sprint 4 : à activer (TODO S4-06)")]
    public void Creneaux_A12h07_LePremierEst12h30()
    {
        List<DateTime> creneaux = CreneauService.CreneauxDisponibles(Le18Novembre(12, 7), Ouverture, Fermeture);
        Assert.Equal(Le18Novembre(12, 30), creneaux[0]);
    }

    [Fact(Skip = "Sprint 4 : à activer (TODO S4-06)")]
    public void Creneaux_A12h10_LePremierEst12h30()
    {
        // 12:10 + 20 minutes = 12:30 : le créneau de 12:30 est encore possible.
        List<DateTime> creneaux = CreneauService.CreneauxDisponibles(Le18Novembre(12, 10), Ouverture, Fermeture);
        Assert.Equal(Le18Novembre(12, 30), creneaux[0]);
    }

    [Fact(Skip = "Sprint 4 : à activer (TODO S4-06)")]
    public void Creneaux_A12h07_LeDernierEst22h45()
    {
        List<DateTime> creneaux = CreneauService.CreneauxDisponibles(Le18Novembre(12, 7), Ouverture, Fermeture);
        Assert.Equal(Le18Novembre(22, 45), creneaux[creneaux.Count - 1]);
    }

    [Fact(Skip = "Sprint 4 : à activer (TODO S4-06)")]
    public void Creneaux_A12h07_IlYEnA42()
    {
        // De 12:30 à 22:45, un créneau tous les quarts d'heure : 42 créneaux.
        List<DateTime> creneaux = CreneauService.CreneauxDisponibles(Le18Novembre(12, 7), Ouverture, Fermeture);
        Assert.Equal(42, creneaux.Count);
    }

    [Fact(Skip = "Sprint 4 : à activer (TODO S4-06)")]
    public void Creneaux_AvantLOuverture_LePremierEstALOuverture()
    {
        List<DateTime> creneaux = CreneauService.CreneauxDisponibles(Le18Novembre(10, 0), Ouverture, Fermeture);
        Assert.Equal(Le18Novembre(11, 30), creneaux[0]);
    }

    [Fact(Skip = "Sprint 4 : à activer (TODO S4-06)")]
    public void Creneaux_A22h50_AucunCreneau()
    {
        List<DateTime> creneaux = CreneauService.CreneauxDisponibles(Le18Novembre(22, 50), Ouverture, Fermeture);
        Assert.Empty(creneaux);
    }

    [Fact(Skip = "Sprint 4 : à activer (TODO S4-06)")]
    public void CodeRetrait_ContientToujours4Chiffres()
    {
        // On essaie 1 000 fois, car le code est tiré au hasard.
        for (int essai = 0; essai < 1000; essai++)
        {
            string code = CommandeService.GenererCodeRetrait();
            Assert.Equal(4, code.Length);
            Assert.True(code.All(char.IsDigit), "Le code ne doit contenir que des chiffres : " + code);
        }
    }

    [Fact(Skip = "Sprint 4 : à activer (TODO S4-06)")]
    public void CodeRetrait_NEstPasToujoursLeMeme()
    {
        var codes = new HashSet<string>();
        for (int essai = 0; essai < 50; essai++)
        {
            codes.Add(CommandeService.GenererCodeRetrait());
        }
        Assert.True(codes.Count > 1, "Le code doit être tiré au hasard.");
    }
}
