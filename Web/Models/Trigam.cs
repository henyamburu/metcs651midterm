using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Web.Models
{
    public sealed class Trigram : Strategy
    {

        public Trigram()
        {
            Ciphers = TrigamFrequency
                .OrderByDescending(l => l.Value)
                .Select((l, i) => new Cipher { Word = l.Key, Index = ++i })
                .ToList();
        }
        public override string Decode(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                //Obtain a list of bigram words
                IList<Cipher> words = SubString(value, 0, 3);

                //Deteremine word frequency.
                var wordFrequency = words
                    .GroupBy(s => s.Word)
                    .OrderByDescending(s => s.Count())
                    .Select((s, i) => new { Word = s.Key, count = s.Count(), Index = ++i })
                    .ToList();

                //Decode message by relating character frequency with letter frequency in
                //look-up cipher.
                var results = (from cipher in Ciphers
                               join wrdFrq in wordFrequency on cipher.Index equals wrdFrq.Index
                               select new { CipherWord = cipher.Word, FrequentWord = wrdFrq.Word }).ToList();

                Enumerable.Range(0, results.Count)
                    .ToList()
                    .ForEach(delegate (int index)
                    {
                        value = Regex.Replace(value, results[index].FrequentWord, results[index].CipherWord, RegexOptions.IgnoreCase);
                    });

                return value.ToLower();


            }
            return string.Empty;
        }
                
        IList<Cipher> SubString(string value, int startIndex, int length)
        {
            IList<Cipher> items = new List<Cipher>();
            if (!string.IsNullOrWhiteSpace(value))
            {
                var words = value.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    if (word.Length <= length)
                        items.Add(new Cipher { Word = word, Index = items.Count });
                    else
                    {
                        var results = Enumerable.Range(startIndex, (int)Math.Ceiling(((double)word.Length / (double)length)))
                            .Select(i => word.Substring(i * length, (i * length + length <= word.Length) ? length : word.Length - i * length));

                        foreach (string result in results)
                        {
                            items.Add(new Cipher { Word = result, Index = items.Count });
                        }
                    }
                }

                return items;
            }

            return items;
        }
    }
}