public class UtilisateurDTO
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public string Prenom { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool Retard { get; set; } = false;
    public int Emprunt { get; set; }
    public List<int> Documents { get; set; } = new List<int>();

    public UtilisateurDTO(Utilisateur utilisateur, ApiMediathequeContext context)
    {
        Id = utilisateur.Id;
        Nom = utilisateur.Nom;
        Prenom = utilisateur.Prenom;
        Email = utilisateur.Email;
        Retard = context.Emprunts.Any(e => e.EmprunteurId == utilisateur.Id && e.DateEmprunt.AddDays(15) < DateTime.Now);
        Emprunt = context.Emprunts.Count(e => e.EmprunteurId == utilisateur.Id);
        Documents = context.Emprunts
            .Where(e => e.EmprunteurId == utilisateur.Id)
            .Select(e => e.EmprunteId)
            .ToList();
    }
}


