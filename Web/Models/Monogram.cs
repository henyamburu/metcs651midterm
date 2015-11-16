using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public sealed class Monogram: Strategy
    {
        public Monogram()
        {
            Ciphers = LetterFrequency
                .OrderByDescending(l => l.Value)
                .Select((l, i) => new Cipher { Word = l.Key, Index = ++i })
                .ToList();
        }
        public override string Decode(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                //Convert string to characters and assign index to mark position 
                //character occurence in the string.
                var characters = value.ToUpper()
                    .ToCharArray()
                    .Select((s, i) => new { Letter = s, Index = ++i });

                //Deteremine character frequency.
                var characterFrequency = characters
                    .GroupBy(s => s.Letter)
                    .OrderByDescending(s => s.Count())
                    .Select((s, i) => new { Letter = s.Key, count = s.Count(), Index = ++i })
                    .ToList();

                //Decode message by relating character frequency with letter frequency in
                //look-up cipher.
                var results = (from cipher in Ciphers
                           join charFrequency in characterFrequency on cipher.Index equals charFrequency.Index
                           join character in characters on charFrequency.Letter equals character.Letter
                           orderby character.Index
                           select cipher.Word).ToList();

                //Reconsitute characters.
                return string.Concat(results).ToLower();
            }

            return string.Empty;
        }

        public override string ToString()
        {
            return string.Format("{0}", Ciphers.Select(c => c.Word + " ").ToArray());
        }
    }
}