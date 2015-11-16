using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Web.Models
{
    public abstract class Strategy
    {
        protected Dictionary<string, double> LetterFrequency = new Dictionary<string, double>();
        protected Dictionary<string, double> BigramFrequency = new Dictionary<string, double>();
        protected Dictionary<string, int> TrigamFrequency = new Dictionary<string, int>();
        protected Dictionary<string, string> GoldBugSubstitution = new Dictionary<string, string>();
        protected IList<Cipher> Ciphers;

        public Strategy()
        {
            LetterFrequency.Add("A", 8.167);
            LetterFrequency.Add("B", 1.492);
            LetterFrequency.Add("C", 2.782);
            LetterFrequency.Add("D", 4.253);
            LetterFrequency.Add("E", 12.702);
            LetterFrequency.Add("F", 2.228);
            LetterFrequency.Add("G", 2.015);
            LetterFrequency.Add("H", 6.094);
            LetterFrequency.Add("I", 6.966);
            LetterFrequency.Add("J", 0.153);
            LetterFrequency.Add("K", 0.772);
            LetterFrequency.Add("L", 4.025);
            LetterFrequency.Add("M", 2.406);
            LetterFrequency.Add("N", 6.749);
            LetterFrequency.Add("O", 7.507);
            LetterFrequency.Add("P", 1.929);
            LetterFrequency.Add("Q", 0.095);
            LetterFrequency.Add("R", 5.987);
            LetterFrequency.Add("S", 6.327);
            LetterFrequency.Add("T", 9.056);
            LetterFrequency.Add("U", 2.758);
            LetterFrequency.Add("V", 0.978);
            LetterFrequency.Add("W", 2.360);
            LetterFrequency.Add("X", 0.150);
            LetterFrequency.Add("Y", 1.974);
            LetterFrequency.Add("Z", 0.074);

            BigramFrequency.Add("TH", 1.52);
            BigramFrequency.Add("EN", 0.55);
            BigramFrequency.Add("HE", 1.28);
            BigramFrequency.Add("ED", 0.53);
            BigramFrequency.Add("OF", 0.16);
            BigramFrequency.Add("IN", 0.94);
            BigramFrequency.Add("TO", 0.52);
            BigramFrequency.Add("AL", 0.09);
            BigramFrequency.Add("ER", 0.94);
            BigramFrequency.Add("IT", 0.50);
            BigramFrequency.Add("DE", 0.09);
            BigramFrequency.Add("AN", 0.82);
            BigramFrequency.Add("OU", 0.50);
            BigramFrequency.Add("SE", 0.08);
            BigramFrequency.Add("RE", 0.68);
            BigramFrequency.Add("EA", 0.47);
            BigramFrequency.Add("LE", 0.08);
            BigramFrequency.Add("ND", 0.63);
            BigramFrequency.Add("HI", 0.46);
            BigramFrequency.Add("SA", 0.06);
            BigramFrequency.Add("AT", 0.59);
            BigramFrequency.Add("IS", 0.46);
            BigramFrequency.Add("SI", 0.05);
            BigramFrequency.Add("ON", 0.57);
            BigramFrequency.Add("OR", 0.43);
            BigramFrequency.Add("AR", 0.04);
            BigramFrequency.Add("NT", 0.56);
            BigramFrequency.Add("TI", 0.34);
            BigramFrequency.Add("VE", 0.04);
            BigramFrequency.Add("HA", 0.56);
            BigramFrequency.Add("AS", 0.33);
            BigramFrequency.Add("RA", 0.04);
            BigramFrequency.Add("ES", 0.56);
            BigramFrequency.Add("TE", 0.27);
            BigramFrequency.Add("LD", 0.02);
            BigramFrequency.Add("ST", 0.55);
            BigramFrequency.Add("ET", 0.19);
            BigramFrequency.Add("UR", 0.02);

            TrigamFrequency.Add("THE", 1);
            TrigamFrequency.Add("AND", 2);
            TrigamFrequency.Add("THA", 3);
            TrigamFrequency.Add("ENT", 4);
            TrigamFrequency.Add("ING", 5);
            TrigamFrequency.Add("ION", 6);
            TrigamFrequency.Add("TIO", 7);
            TrigamFrequency.Add("FOR", 8);
            TrigamFrequency.Add("NDE", 9);
            TrigamFrequency.Add("HAS", 10);
            TrigamFrequency.Add("NCE", 11);
            TrigamFrequency.Add("EDT", 12);
            TrigamFrequency.Add("TIS", 13);
            TrigamFrequency.Add("OFT", 14);
            TrigamFrequency.Add("STH", 15);
            TrigamFrequency.Add("MEN", 16);

            GoldBugSubstitution.Add("0", "l");
            GoldBugSubstitution.Add("1", "f");
            GoldBugSubstitution.Add("2", "b");
            GoldBugSubstitution.Add("3", "g");
            GoldBugSubstitution.Add("4", "h");
            GoldBugSubstitution.Add("5", "a");
            GoldBugSubstitution.Add("6", "i");
            GoldBugSubstitution.Add("7", "k");
            GoldBugSubstitution.Add("8", "e");
            GoldBugSubstitution.Add("9", "m");
            GoldBugSubstitution.Add(".", "p");
            GoldBugSubstitution.Add(",", "j");
            GoldBugSubstitution.Add(":", "y");
            GoldBugSubstitution.Add(";", "t");
            GoldBugSubstitution.Add("(", "r");
            GoldBugSubstitution.Add(")", "s");
            GoldBugSubstitution.Add("[", "z");
            GoldBugSubstitution.Add("]", "w");
            GoldBugSubstitution.Add("†", "d");
            GoldBugSubstitution.Add("‡", "o");
            GoldBugSubstitution.Add("$", "q");
            GoldBugSubstitution.Add("¢", "x");
            GoldBugSubstitution.Add("-", "c");
            GoldBugSubstitution.Add("*", "n");
            GoldBugSubstitution.Add("?", "u");
            GoldBugSubstitution.Add("¶", "g");
        }
        public abstract string Decode(string value);

        public override string ToString()
        {
            return "Strategy";
        }
    }
}