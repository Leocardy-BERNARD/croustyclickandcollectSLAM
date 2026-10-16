using System.Text.Json;
using CroustyClickCollect.Models;

namespace CroustyClickCollect.Services;

/// <summary>
/// Range le panier et le restaurant choisi dans la SESSION du visiteur.
/// La session est une petite mémoire, propre à chaque visiteur, gardée par le
/// serveur pendant sa visite. Elle ne stocke que du texte ou des nombres :
/// on transforme donc le panier en texte JSON pour l'y ranger.
/// </summary>
public static class PanierSession
{
    private const string CleRestaurant = "RestaurantId";
    private const string ClePanier = "Panier";

    public static List<LignePanier> Lire(ISession session)
    {
        string json = session.GetString(ClePanier);
        if (string.IsNullOrEmpty(json))
        {
            return new List<LignePanier>();   // pas encore de panier : liste vide
        }
        return JsonSerializer.Deserialize<List<LignePanier>>(json);
    }

    public static void Enregistrer(ISession session, List<LignePanier> panier)
    {
        session.SetString(ClePanier, JsonSerializer.Serialize(panier));
    }

    public static void Vider(ISession session)
    {
        session.Remove(ClePanier);
    }

    // Renvoie l'id du restaurant choisi, ou null si le visiteur n'en a pas encore choisi.
    public static int? LireRestaurant(ISession session)
    {
        return session.GetInt32(CleRestaurant);
    }

    public static void EnregistrerRestaurant(ISession session, int restaurantId)
    {
        // TODO S3-02 (sprint 3) : mémoriser le restaurant choisi par le visiteur (C1).
        //   Consigne : ranger restaurantId dans la session, sous la clé CleRestaurant.
        //   Indice   : la session fonctionne comme un dictionnaire. Regardez comment
        //              LireRestaurant() relit la valeur juste au-dessus : il existe
        //              une méthode « Set… » qui fait l'inverse.
    }
}
