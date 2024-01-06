public class SeedData
{
    public static void Init()
    {
        using var context = new ApiMediathequeContext();
        /*if (context.Documents.Any())
        {
            return;   // DB already filled
        }
        if (context.Utilisateurs.Any())
        {
            return;   // DB already filled
        }
        if (context.Emprunts.Any())
        {
            return;   // DB already filled
        }*/

        // Add documents
        Document GenieLogPourLesNuls = new Document
        {
            Id = 1,
            Titre = "Le génie logiciel pour les nuls",
            Auteur = "Simon Tauvron",
            Stock = 10,
        };

        Document HistoireDuRicard = new Document
        {
            Id = 2,
            Titre = "L'histoire du ricard",
            Auteur = "Clement Goy",
            Stock = 1,
        };

        Document JujutsuKaisen = new Document
        {
            Id = 3,
            Titre = "Jujutsu Kaisen",
            Auteur = "Gege",
            Stock = 9,
        };

        Document Dictionnaire = new Document
        {
            Id = 4,
            Titre = "Dictionnaire",
            Auteur = "Alain Robert",
            Stock = 3,
        };

        context.Documents.AddRange(
            GenieLogPourLesNuls,
            HistoireDuRicard,
            JujutsuKaisen,
            Dictionnaire
        );

        // Add Utilisateurs
        Utilisateur SimonTauvron = new Utilisateur
        {
            Id = 1,
            Nom = "Tauvron",
            Prenom = "Simon",
            Email = "stauvron@ensc.fr",
        };

        Utilisateur ClementGoy = new Utilisateur
        {
            Id = 2,
            Nom = "Goy",
            Prenom = "Clement",
            Email = "cgoy@ensc.fr",
        };

        Utilisateur RafaelNadal = new Utilisateur
        {
            Id = 3,
            Nom = "Nadal",
            Prenom = "Rafael",
            Email = "rnadal@ensc.fr",
        };

        Utilisateur MaxVerstappen = new Utilisateur
        {
            Id = 4,
            Nom = "Verstappen",
            Prenom = "Max",
            Email = "mverstappen@ensc.fr",
        };

        context.Utilisateurs.AddRange(
            SimonTauvron,
            ClementGoy,
            RafaelNadal,
            MaxVerstappen
        );

        context.SaveChanges();
    }
}


