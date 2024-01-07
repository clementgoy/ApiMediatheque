public class MagazineDTO : DocumentDTO
{
    public DateTime Publication { get; set; }

    public MagazineDTO(Magazine magasine) : base(magasine)
    {
        Publication = magasine.Publication;
    }
}
