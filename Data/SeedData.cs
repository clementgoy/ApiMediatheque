public class SeedData {
    public void Init() {
        using var context=new ApiMediathequeContext();
        if (context.Documents.Any())
        {
            return;   // DB already filled
        }
                Document GenieLogPourLesNuls = new Document
                {
                    Titre = "Le génie logiciel pour les nuls",
                    Auteur = "Siment",
                    Stock = 10,
                };

                Document HistoireDuRicard = new Document
                {
                    Titre = "L'histoire du ricard",
                    Auteur = "Clemon",
                    Stock = 5,
                };
                
                context.Documents.AddRange(
                    GenieLogPourLesNuls, 
                    HistoireDuRicard
                );
                context.SaveChanges();
    }
}


