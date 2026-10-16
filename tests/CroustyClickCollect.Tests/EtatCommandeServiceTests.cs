using CroustyClickCollect.Models;
using CroustyClickCollect.Services;

namespace CroustyClickCollect.Tests;

/// <summary>
/// Tests du cycle de vie d'une commande (RG6), sprint 5.
/// </summary>
public class EtatCommandeServiceTests
{
    // TODO S5-08 (sprint 5) : activer les tests du cycle de vie d'une commande.
    //   Consigne : quand le TODO S5-05 est fait, retirez « (Skip = "...") », puis lancez les tests.
    //   Indice   : [Theory] + [InlineData] lance le même test avec plusieurs jeux de valeurs.

    [Theory(Skip = "Sprint 5 : à activer (TODO S5-08)")]
    [InlineData(EtatCommande.Recue, EtatCommande.EnPreparation)]
    [InlineData(EtatCommande.EnPreparation, EtatCommande.Prete)]
    [InlineData(EtatCommande.Prete, EtatCommande.Retiree)]
    public void EtatSuivant_AvanceDUneEtape(string etatActuel, string etatAttendu)
    {
        Assert.Equal(etatAttendu, EtatCommandeService.EtatSuivant(etatActuel));
    }

    [Theory(Skip = "Sprint 5 : à activer (TODO S5-08)")]
    [InlineData(EtatCommande.Retiree)]
    [InlineData(EtatCommande.Annulee)]
    public void EtatSuivant_CommandeTerminee_PasDEtatSuivant(string etatActuel)
    {
        Assert.Null(EtatCommandeService.EtatSuivant(etatActuel));
    }
}
