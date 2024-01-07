public enum SupportMedia
{
        Audio,
        Video
}

public class Media : Document
{
        public SupportMedia Support { get; set; }
        public override string Type => "Media";

        public Media(MediaDTO mediaDTO, ApiMediathequeContext context)
        {
                if (Enum.TryParse<SupportMedia>(mediaDTO.Support, out var support))
                {
                        Support = support;
                }
                else
                {
                        throw new ArgumentException($"La valeur du support '{mediaDTO.Support}' n'est pas valide.");

                }

        }
}

