public class Utilisateur
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Email { get; set; }
    
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }

        public Utilisateur() { }

        public Utilisateur(UtilisateurDTO utilisateurDTO)
        {
            Id = utilisateurDTO.Id;
            Nom = utilisateurDTO.Nom;
            Prenom = utilisateurDTO.Prenom;
            Email = utilisateurDTO.Email;
        }
    }
}