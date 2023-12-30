public class Emprunt
{
    public int Id { get; set; }
    public Utilisateur Emprunteur { get; set; } = null!;
    public Document Emprunte { get; set; } = null!;
    public Emprunt () {}
}