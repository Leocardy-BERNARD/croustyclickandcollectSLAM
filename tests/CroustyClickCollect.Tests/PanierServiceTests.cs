using CroustyClickCollect.Models;
using CroustyClickCollect.Services;

namespace CroustyClickCollect.Tests;

/// <summary>
/// Tests unitaires du panier.
/// Un test se lit en 3 temps : PRÉPARER les données, AGIR (appeler la méthode),
/// VÉRIFIER le résultat avec Assert. Lancez-les avec : dotnet test
///
/// Les tests marqués « Skip » sont ignorés pour l'instant. Au sprint 3, quand
/// vous avez écrit PanierService, retirez le « (Skip = "...") » pour les activer.
/// </summary>
public class PanierServiceTests
{
    // Petite méthode d'aide pour fabriquer une ligne de panier en une ligne de code.
    private static LignePanier Ligne(int produitId, int? sauceId, decimal prix, int quantite)
    {
        return new LignePanier { ProduitId = produitId, SauceId = sauceId, PrixUnitaire = prix, Quantite = quantite };
    }

    // EXEMPLE : ce test est déjà actif. Il vérifie CompterArticles(), déjà écrite.
    [Fact]
    public void CompterArticles_AdditionneLesQuantites()
    {
        // Préparer : 2 crousty classiques + 1 soda
        var panier = new List<LignePanier> { Ligne(1, 1, 9.00m, 2), Ligne(8, null, 2.50m, 1) };

        // Agir
        int nombre = PanierService.CompterArticles(panier);

        // Vérifier : on attend 3 articles
        Assert.Equal(3, nombre);
    }

    // TODO S3-08 (sprint 3) : activer les tests du panier.
    //   Consigne : quand les TODO S3-03 à S3-06 sont faits, retirez « (Skip = "...") »
    //              de chaque test ci-dessous, puis lancez « dotnet test ».
    //   Indice   : un test rouge vous dit quelle valeur était attendue et laquelle a été obtenue.

    [Fact(Skip = "Sprint 3 : à activer (TODO S3-08)")]
    public void CalculerTotal_DeuxCroustyEtUnSoda_Donne20Euros50()
    {
        var panier = new List<LignePanier> { Ligne(1, 1, 9.00m, 2), Ligne(8, null, 2.50m, 1) };
        Assert.Equal(20.50m, PanierService.CalculerTotal(panier));
    }

    [Fact(Skip = "Sprint 3 : à activer (TODO S3-08)")]
    public void CalculerTotal_PanierVide_Donne0()
    {
        Assert.Equal(0m, PanierService.CalculerTotal(new List<LignePanier>()));
    }

    [Fact(Skip = "Sprint 3 : à activer (TODO S3-08)")]
    public void Ajouter_MemeProduitMemeSauce_AugmenteLaQuantite()
    {
        var panier = new List<LignePanier> { Ligne(1, 1, 9.00m, 1) };
        PanierService.Ajouter(panier, Ligne(1, 1, 9.00m, 2));
        Assert.Single(panier);              // toujours une seule ligne…
        Assert.Equal(3, panier[0].Quantite); // … mais avec une quantité de 3
    }

    [Fact(Skip = "Sprint 3 : à activer (TODO S3-08)")]
    public void Ajouter_MemeProduitAutreSauce_AjouteUneLigne()
    {
        var panier = new List<LignePanier> { Ligne(1, 1, 9.00m, 1) };
        PanierService.Ajouter(panier, Ligne(1, 2, 9.00m, 1));
        Assert.Equal(2, panier.Count);
    }

    [Fact(Skip = "Sprint 3 : à activer (TODO S3-08)")]
    public void Retirer_PremiereLigne_LaSupprime()
    {
        var panier = new List<LignePanier> { Ligne(1, 1, 9.00m, 1), Ligne(8, null, 2.50m, 1) };
        PanierService.Retirer(panier, 0);
        Assert.Single(panier);
        Assert.Equal(8, panier[0].ProduitId);
    }

    [Fact(Skip = "Sprint 3 : à activer (TODO S3-08)")]
    public void Retirer_PositionInexistante_NeChangeRien()
    {
        var panier = new List<LignePanier> { Ligne(1, 1, 9.00m, 1) };
        PanierService.Retirer(panier, 5);
        Assert.Single(panier);
    }

    [Fact(Skip = "Sprint 3 : à activer (TODO S3-08)")]
    public void PeutAjouter_NeufArticlesPlusUn_Accepte()
    {
        var panier = new List<LignePanier> { Ligne(1, 1, 9.00m, 9) };
        Assert.True(PanierService.PeutAjouter(panier, 1));
    }

    [Fact(Skip = "Sprint 3 : à activer (TODO S3-08)")]
    public void PeutAjouter_DixArticlesPlusUn_Refuse()
    {
        var panier = new List<LignePanier> { Ligne(1, 1, 9.00m, 10) };
        Assert.False(PanierService.PeutAjouter(panier, 1));
    }
}
