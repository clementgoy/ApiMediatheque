public class Utilisateur
{
    public int Id { get; set; }
    public string? Nom { get; set; }
    public string? Prenom { get; set; }
    public string? Email {get; set; }
    public List<Document> Docs {get; set; } = null!;
    
}