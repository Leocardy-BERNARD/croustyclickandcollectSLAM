using MySqlConnector;

namespace CroustyClickCollect.Data;

/// <summary>
/// Fabrique les connexions à la base MySQL / MariaDB.
/// Les informations de connexion viennent du fichier .env, jamais du code
/// (BONNE PRATIQUE du bloc 3). Vous n'avez pas besoin de modifier ce fichier.
/// </summary>
public class BaseDeDonnees
{
    private readonly string _chaineConnexion;

    // IConfiguration donne accès aux variables lues dans le fichier .env.
    public BaseDeDonnees(IConfiguration configuration)
    {
        var infos = new MySqlConnectionStringBuilder
        {
            Server = configuration["DB_HOST"] ?? "localhost",
            Port = uint.Parse(configuration["DB_PORT"] ?? "3306"),
            Database = configuration["DB_NAME"] ?? "crousty",
            UserID = configuration["DB_USER"] ?? "",
            Password = configuration["DB_PASSWORD"] ?? ""
        };
        _chaineConnexion = infos.ConnectionString;
    }

    /// <summary>
    /// Renvoie une nouvelle connexion. Écrivez toujours « using var connexion = ... » :
    /// grâce au mot « using », la connexion est refermée automatiquement à la fin de la méthode.
    /// </summary>
    public MySqlConnection CreerConnexion()
    {
        return new MySqlConnection(_chaineConnexion);
    }
}
