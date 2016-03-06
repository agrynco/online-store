namespace OS.Business.Domain
{
    public class NamedPublishedEntity : NamedEntity, IPublishedEntity
    {
        public NamedPublishedEntity()
        {
            Publish = true;
        }

        public bool Publish { get; set; }
    }
}