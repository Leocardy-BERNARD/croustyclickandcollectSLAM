using CroustyClickCollect.Models;
using Dapper;

namespace CroustyClickCollect.Data;

/// <summary>
/// Toutes les requêtes SQL qui concernent le personnel des restaurants.
/// </summary>
public class PersonnelRepository
{
    private readonly BaseDeDonnees _bdd;

    public PersonnelRepository(BaseDeDonnees bdd)
    {
        _bdd = bdd;
    }

    public Personnel GetParIdentifiant(string identifiant)
    {
        // TODO S5-01 (sprint 5) : retrouver un membre du personnel par son identifiant.
        //   Consigne : renvoyer la personne dont l'identifiant est reçu, ou null.
        //   Indice   : même principe que RestaurantRepository.GetParId(). C'est ici
        //              que la requête paramétrée est vitale : l'identifiant est tapé
        //              par l'utilisateur dans le formulaire de connexion.
        return null;
    }
}
