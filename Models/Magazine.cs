public class Magazine : Document
{
        public DateTime Publication { get; set; }
        public override string Type => "Magazine";
        public Magazine(MagazineDTO magazineDTO, ApiMediathequeContext context)
        {
                Publication = magazineDTO.Publication;
        }
}
