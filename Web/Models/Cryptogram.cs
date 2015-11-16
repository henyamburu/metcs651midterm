using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Web.Models
{
    [Serializable]
    public class Cryptogram : Strategy
    {
        public override string Decode(string value)
        {
            if(!string.IsNullOrWhiteSpace(value))
            {
                var characters =  Array.ConvertAll(value.ToCharArray(), new Converter<char, string>(CharToString)).Distinct().ToList();
                
                characters.ForEach(delegate(string character) {
                    value = value.Replace(character, GoldBugSubstitution[character]);
                } );

                return value.ToLower();
            }

            return string.Empty;
        }

        static string CharToString(char value)
        {
            return value.ToString();
        }
    }
}