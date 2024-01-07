public class LivreDTO : DocumentDTO
{
    public string Genre { get; set; }

    public LivreDTO(Livre livre) : base(livre)
    {
        Genre = livre.Genre.ToString();
    }
}