namespace CroustyClickCollect.Outils;

/// <summary>
/// Lit le fichier .env et transforme chaque ligne « NOM=valeur » en variable
/// d'environnement, que le reste du site peut ensuite lire.
///
/// Pourquoi ? BONNE PRATIQUE (bloc 3) : les mots de passe restent HORS du
/// code source. Le fichier .env n'est jamais envoyé sur GitHub (voir .gitignore).
/// Vous n'avez pas besoin de modifier ce fichier.
/// </summary>
public static class FichierEnv
{
    public static void Charger()
    {
        string chemin = TrouverFichier();
        if (chemin == null)
        {
            Console.WriteLine("ATTENTION : fichier .env introuvable. Copiez .env.example en .env (voir README).");
            return;
        }

        foreach (string ligne in File.ReadAllLines(chemin))
        {
            string texte = ligne.Trim();

            // On ignore les lignes vides et les commentaires (qui commencent par #).
            if (texte == "" || texte.StartsWith("#"))
            {
                continue;
            }

            int positionEgal = texte.IndexOf('=');
            if (positionEgal <= 0)
            {
                continue;
            }

            string nom = texte.Substring(0, positionEgal).Trim();
            string valeur = texte.Substring(positionEgal + 1).Trim();

            // Une variable déjà définie (par exemple sur le serveur en ligne) reste prioritaire.
            if (Environment.GetEnvironmentVariable(nom) == null)
            {
                Environment.SetEnvironmentVariable(nom, valeur);
            }
        }
    }

    // Cherche .env dans le dossier courant, puis dans les dossiers parents :
    // le site peut être lancé depuis src/CroustyClickCollect ou depuis la racine du dépôt.
    private static string TrouverFichier()
    {
        DirectoryInfo dossier = new DirectoryInfo(Directory.GetCurrentDirectory());
        while (dossier != null)
        {
            string chemin = Path.Combine(dossier.FullName, ".env");
            if (File.Exists(chemin))
            {
                return chemin;
            }
            dossier = dossier.Parent;
        }
        return null;
    }
}
