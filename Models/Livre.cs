public enum GenreLivre
{
        Roman,
        Scolaire,
        Enfant
}

public class Livre : Document
{
        public GenreLivre Genre { get; set; }

        public Livre(LivreDTO livreDTO, ApiMediathequeContext context)
        {
                if (Enum.TryParse<GenreLivre>(livreDTO.Genre, out var genre))
                {
                        Genre = genre;
                }
                else
                {
                        throw new ArgumentException($"La valeur du genre '{livreDTO.Genre}' n'est pas valide.");

                }

        }
}

