public abstract class Document
{
    public int Id { get; set; }
    public string Titre { get; set; }
    public string Auteur { get; set; }
    public int Stock { get; set; }
    public int Emprunt { get; set; }
    public List<int> EmprunteurIds { get; set; } = new List<int>();
    public abstract string Type { get; }

    public Document() { }

    public Document(DocumentDTO documentDTO, ApiMediathequeContext context)
    {
        Titre = documentDTO.Titre;
        Auteur = documentDTO.Auteur;
        Stock = documentDTO.Stock;
        Emprunt = 0;
        EmprunteurIds = new List<int>();

    }
}

