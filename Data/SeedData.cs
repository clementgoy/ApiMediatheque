public class SeedData
{
    public void Init()
    {
        using var context = new ApiMediathequeContext();
        if (context.Documents.Any())
        {
            return;   // DB already filled
        }
        /* if (context.Utilisateurs.Any())
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
            Titre = "Le génie logiciel pour les nuls",
            Auteur = "Simon Tauvron",
            Stock = 10,
        };

        Document HistoireDuRicard = new Document
        {
            Titre = "L'histoire du ricard",
            Auteur = "Clement Goy",
            Stock = 5,
        };

        context.Documents.AddRange(
            GenieLogPourLesNuls,
            HistoireDuRicard
        );

        // Add Utilisateurs
        Utilisateur SimonTauvron = new Utilisateur
        {
            Nom = "Simon",
            Prenom = "Tauvron",
            Email = "stauvron@ensc.fr",
        };

        Utilisateur ClementGoy = new Utilisateur
        {
            Nom = "Clement",
            Prenom = "Goy",
            Email = "cgoy@ensc.fr",
        };

        context.Utilisateurs.AddRange(
            SimonTauvron,
            ClementGoy
        );

        // Add Emprunts
        Emprunt E1 = new Emprunt
        {
            EmprunteurId = 1,
            EmprunteId = 2,
            // SimonTauvron emprunte HistoireDuRicard
        };

        context.Emprunts.AddRange(
            E1);

        context.SaveChanges();
    }
}


