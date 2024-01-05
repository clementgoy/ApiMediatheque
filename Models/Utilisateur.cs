public class Utilisateur
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Email { get; set; }
    public Utilisateur () {}

    public Utilisateur(UtilisateurDTO utilisateurDTO)
    {
        Nom = UtilisateurDTO.Nom;
        Prenom = UtilisateurDTO.Prenom;
        Email = UtilisateurDTO.Email;
    }

}