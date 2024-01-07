public class Utilisateur
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Email { get; set; }
    public bool Retard { get; set; } = false;
    public int Emprunt { get; set; }
    public List<int> Documents { get; set; } = new List<int>();
    public Utilisateur() { }

    public Utilisateur(UtilisateurDTO utilisateurDTO, ApiMediathequeContext context)
    {
        Nom = utilisateurDTO.Nom;
        Prenom = utilisateurDTO.Prenom;
        Email = utilisateurDTO.Email;
        Retard = false;
        Emprunt = 0;
        Documents = new List<int>();
    }
}
