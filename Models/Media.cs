public enum SupportMedia
{
        Audio,
        Video
}

public class Media : DocumentDTO
{
        public SupportMedia Support { get; set; }
}

