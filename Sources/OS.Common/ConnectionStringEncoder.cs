#region Usings
using System.Text.RegularExpressions;
#endregion

namespace OS.Common
{
    public static class ConnectionStringEncoder
    {
        public static string Encode(string connectionString)
        {
            string securedConnectionString = connectionString;
            Match userIdMatch = Regex.Match(securedConnectionString, "User ID=(?>.*?;)", RegexOptions.IgnoreCase);
            if (userIdMatch.Success)
            {
                securedConnectionString = securedConnectionString.Replace(userIdMatch.Value, ReplaceValue(userIdMatch.Value));
            }

            Match passwordMatch = Regex.Match(securedConnectionString, "Password=(?>.*?;)", RegexOptions.IgnoreCase);
            if (passwordMatch.Success)
            {
                securedConnectionString = securedConnectionString.Replace(passwordMatch.Value, ReplaceValue(passwordMatch.Value));
            }

            return securedConnectionString;
        }

        private static string ReplaceValue(string keyValue)
        {
            string[] strings = keyValue.Split('=');

            return strings[0] + "=" + "***;";
        }
    }
}