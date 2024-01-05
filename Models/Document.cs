public class Document
{
    public int Id { get; set; }
    public string Titre { get; set; }
    public string Auteur { get; set; }
    public int Stock { get; set; }

    public Document() { }

    public Document(DocumentDTO documentDTO)
    {
        Id = documentDTO.Id;
        Titre = documentDTO.Titre;
        Auteur = documentDTO.Auteur;
        Stock = documentDTO.Stock;
    }
}

