public class Utilisateur
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Email {get; set; }
    public int emprunt { get; set; }
    public List<Document> Emprunts {get; set; } = null!;
}