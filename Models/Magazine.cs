public class Magazine : Document
{
        public DateTime Publication { get; set; }
        public Magazine(MagazineDTO magazineDTO, ApiMediathequeContext context)
        {
                Publication = magazineDTO.Publication;
        }
}
