public class DocumentDTO
{
    public string Titre { get; set; } = null!;
    public string Auteur { get; set; } = null!;
    public int Stock { get; set; }
    
    public DocumentDTO(){}

    public DocumentDTO(Document document)
    {
        Titre = document.Titre;
        Auteur = document.Auteur;
        Stock = document.Stock;
    }
}



