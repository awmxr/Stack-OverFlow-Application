using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClient
{
    class Functions
    {

        // public static List<string> UpdateList = new List<string>();
        public static Dictionary<string, string> UpdateDictionary = new Dictionary<string, string>();
        public static string UrlEncode(IDictionary<string, string> parameters)
        {
            var sb = new StringBuilder();
            foreach (var val in parameters)
            {
                // add each parameter to the query string, url-encoding the value.
                sb.AppendFormat("{0}={1}&", val.Key, val.Value);
            }
            sb.Remove(sb.Length - 1, 1); // remove last '&'
            return sb.ToString();
        }


        public static Dictionary<string, string> UrlDecode(string parameters)
        {
            Dictionary<string, string> parametrsDictionary = new Dictionary<string, string>();
            var queryDictionary = System.Web.HttpUtility.ParseQueryString(parameters);

            foreach (var key in queryDictionary.Keys)
            {
                parametrsDictionary[key.ToString()] = queryDictionary.Get(key.ToString()).ToString();
            }

            return parametrsDictionary;
        }


        public static string HashString(string text, string salt = "")
        {
            if (String.IsNullOrEmpty(text))
            {
                return String.Empty;
            }

            // Uses SHA256 to create the hash
            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                // Convert the string to a byte array first, to be processed
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(text + salt);
                byte[] hashBytes = sha.ComputeHash(textBytes);

                // Convert back to a string, removing the '-' that BitConverter adds
                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", String.Empty);

                return hash;
            }
        }

        public static string Replace_Fin(string a)
        {
            // string x = "Hello [first] [second] world";

            StringBuilder builder = new StringBuilder(a);
            builder.Replace(Setting.fin, "");
            

            string b = builder.ToString(); // Value of y is "Hello 1st 2nd world"

            return b;
        }


    }
}
