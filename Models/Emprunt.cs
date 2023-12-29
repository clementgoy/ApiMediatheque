public class Emprunt
{
    public int Id { get; set; }
    public Utilisateur Emprunteur { get; set; }
    public Document Emprunte { get; set; }
}