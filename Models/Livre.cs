public enum GenreLivre
{
        Roman,
        Scolaire,
        Enfant
}

public class Livre : DocumentDTO
{
        public GenreLivre Genre { get; set; }
}

