public class Document
{
    public int Id { get; set; }
    public string Titre { get; set; }
    public string Auteur { get; set; }
    public int Stock { get; set; }
    public int emprunt { get; set; }
    public List<Utilisateur> Emprunteurs {get; set; } = null!;
}
