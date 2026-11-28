using CroustyClickCollect.Models;

namespace CroustyClickCollect.Services;

/// <summary>
/// Les règles du panier. Le panier est une simple liste de LignePanier.
/// Ces méthodes ne touchent ni à la base ni à la session : elles sont donc
/// faciles à tester (voir tests/.../PanierServiceTests.cs).
/// </summary>
public static class PanierService
{
    // Règle RG2 : une commande contient au maximum 10 articles.
    public const int ArticlesMaximum = 10;

    // EXEMPLE COMPLET : nombre total d'articles, en tenant compte des quantités.
    // 2 crousty + 1 soda = 3 articles.
    public static int CompterArticles(List<LignePanier> panier)
    {
        int total = 0;
        foreach (LignePanier ligne in panier)
        {
            total = total + ligne.Quantite;
        }
        return total;
    }

    public static void Ajouter(List<LignePanier> panier, LignePanier nouvelle)
    {
        foreach (var ligne in panier)
        {
            if (ligne.ProduitId == nouvelle.ProduitId && ligne.SauceId == nouvelle.SauceId)
            {
                ligne.Quantite = ligne.Quantite + nouvelle.Quantite;
                return;
            }
        }

        panier.Add(nouvelle);
    }

       public static decimal CalculerTotal(List<LignePanier> panier)
    {
        decimal total = 0;
        foreach (LignePanier ligne in panier)
        {
            total = total + ligne.PrixUnitaire * ligne.Quantite;
        }
        return total;
    }
    public static void Retirer(List<LignePanier> panier, int position)
    {
        // TODO S3-05 (sprint 3) : retirer une ligne du panier (C4).
        //   Consigne : supprimer la ligne qui se trouve à la position reçue
        //              (0 = la première). Si la position n'existe pas, ne rien faire.
        //   Indice   : une liste a une propriété Count et une méthode RemoveAt(position).
    }

    public static bool PeutAjouter(List<LignePanier> panier, int quantite)
    {
        // TODO S3-06 (sprint 3) : appliquer la règle RG2 (10 articles maximum).
        //   Consigne : renvoyer true si on peut ajouter « quantite » articles sans
        //              dépasser ArticlesMaximum, false sinon.
        //   Indice   : utilisez CompterArticles(panier).
        return true;
    }
}
