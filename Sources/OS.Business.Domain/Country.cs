namespace OS.Business.Domain
{
    /// <summary>
    /// Справочник стран мира, их полных и сокращенных названий, столиц, буквенных, цифровых и международных телефонных кодов
    /// http://whoyougle.ru/place/countries/list
    /// </summary>
    public class Country : NamedEntity
    {
        public string EnglishName { get; set; }
        public string ISO { get; set; }
        public string PhoneCode { get; set; }
        public string TwoCharsCode { get; set; }
        public string ThreeCharsCode { get; set; }
    }
}