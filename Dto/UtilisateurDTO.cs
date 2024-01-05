public class UtilisateurDTO
{
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Email { get; set; }
    public UtilisateurDTO () {}

    public UtilisateurDTO(Utilisateur utilisateur)
    {
        Nom = Utilisateur.Nom;
        Prenom = Utilisateur.Prenom;
        Email = Utilisateur.Email;
    }
}