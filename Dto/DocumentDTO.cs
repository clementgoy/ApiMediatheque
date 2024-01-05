public class DocumentDTO
{
    public int Id { get; set; }
    public string Titre { get; set; } = null!;
    public string Auteur { get; set; } = null!;
    public int Stock { get; set; }
    public int Emprunt { get; set; }
    public List<int> EmprunteurIds { get; set; } = new List<int>();

    public DocumentDTO(Document document, ApiMediathequeContext context)
    {
        Id = document.Id;
        Titre = document.Titre;
        Auteur = document.Auteur;
        Stock = document.Stock;
        Emprunt = context.Emprunts.Count(e => e.EmprunteId == document.Id);
        EmprunteurIds = context.Emprunts
            .Where(e => e.EmprunteId == document.Id)
            .Select(e => e.EmprunteurId)
            .ToList();
    }
}



