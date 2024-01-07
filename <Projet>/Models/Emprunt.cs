public class Emprunt
{
    public int Id { get; set; }
    public int EmprunteurId { get; set; }
    public int EmprunteId { get; set; }
    public DateTime DateEmprunt { get; set; }
    public Emprunt() { }
}