using CroustyClickCollect.Services;

namespace CroustyClickCollect.Tests;

/// <summary>
/// Tests de la règle d'ouverture des restaurants (sprint 2).
/// Ces tests sont écrits à l'avance : ils décrivent ce que EstOuvert() doit faire.
/// </summary>
public class HorairesServiceTests
{
    private static readonly TimeSpan Ouverture = new TimeSpan(11, 30, 0);   // 11:30
    private static readonly TimeSpan Fermeture = new TimeSpan(23, 0, 0);    // 23:00

    // TODO S2-03 (sprint 2) : activer les tests des horaires.
    //   Consigne : quand le TODO S2-02 est fait, retirez « (Skip = "...") » de chaque
    //              test ci-dessous, puis lancez « dotnet test » : tout doit être vert.
    //   Indice   : dans Visual Studio, menu Test > Explorateur de tests > Exécuter tout.

    [Fact(Skip = "Sprint 2 : à activer (TODO S2-03)")]
    public void EstOuvert_PileALOuverture_Ouvert()
    {
        Assert.True(HorairesService.EstOuvert(Ouverture, Fermeture, new TimeSpan(11, 30, 0)));
    }

    [Fact(Skip = "Sprint 2 : à activer (TODO S2-03)")]
    public void EstOuvert_UneMinuteAvantLOuverture_Ferme()
    {
        Assert.False(HorairesService.EstOuvert(Ouverture, Fermeture, new TimeSpan(11, 29, 0)));
    }

    [Fact(Skip = "Sprint 2 : à activer (TODO S2-03)")]
    public void EstOuvert_EnPleinMidi_Ouvert()
    {
        Assert.True(HorairesService.EstOuvert(Ouverture, Fermeture, new TimeSpan(12, 45, 0)));
    }

    [Fact(Skip = "Sprint 2 : à activer (TODO S2-03)")]
    public void EstOuvert_PileALaFermeture_Ferme()
    {
        Assert.False(HorairesService.EstOuvert(Ouverture, Fermeture, new TimeSpan(23, 0, 0)));
    }
}
