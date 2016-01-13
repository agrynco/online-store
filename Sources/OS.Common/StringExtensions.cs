namespace OS.Common
{
    public static class StringExtensions
    {
        public static string Trunc(this string s, int maxLength)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            if (s.Length <= maxLength)
            {
                return s;
            }

            string result = s.Substring(0, maxLength);

            return result.TrimEnd();
        } 
    }
}