public class UtilisateurDTO
{
    public string Nom { get; set; } = null!;
    public string Prenom { get; set; } = null!;
    public string Email { get; set; } = null!;

    public UtilisateurDTO(){}

    public UtilisateurDTO(Utilisateur utilisateur)
    {
        Nom = utilisateur.Nom;
        Prenom = utilisateur.Prenom;
        Email = utilisateur.Email;
    }
}


