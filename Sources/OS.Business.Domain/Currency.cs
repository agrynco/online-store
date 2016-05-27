namespace OS.Business.Domain
{
    public class Currency : NamedEntity
    {
        public int Code { get; set; }
        public string CodeISO { get; set; }
        public virtual Country Country { get; set; }
        public int? CountryId { get; set; }
        public string HexSymbol { get; set; }
        public bool IsMain { get; set; }
        public string Symbol { get; set; }
    }
}