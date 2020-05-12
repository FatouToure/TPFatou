using System;

namespace Cryptanalysis
{
    public class Vigenere
    {
        public const float FrenchIndexOfCoincidence = 0.0778F;

        private string key;

        public Vigenere(string key)
        {
            for (int i = 0; i < key.Length; i++)
            {
                if (Tools.LetterIndex(key[i]) == -1)
                {
                    throw new ArgumentException("the key must only contain characters");
                }

            }

            this.key = key;
        }

        public string Encrypt(string msg)
        {
            int indexKey = 0;
            int indexList = key.Length;
            string res = "";

            foreach (var c in msg)
            {
                if (Tools.LetterIndex(c) != -1)
                {
                    res += Tools.RotChar(c, Tools.LetterIndex(key[indexKey]));
                    indexKey = Tools.Modulus(indexKey + 1, indexList);
                }
                else
                {
                    res += c;
                }
            }

            return res;
        }

        public string Decrypt(string cypherText)
        {

            int indexKey = 0;
            int indexList = key.Length;
            string res = "";

            foreach (var c in cypherText)
            {
                if (Tools.LetterIndex(c) != -1)
                {
                    res += Tools.RotChar(c, -Tools.LetterIndex(key[indexKey]));
                    indexKey = Tools.Modulus(indexKey + 1, indexList);
                }
                else
                {
                    res += c;
                }
            }

            return res;
        }

        public static string GuessKeyWithLength(string cypherText, int keyLength)
        {
            throw new NotImplementedException();
        }

        public static float IndexOfCoincidence(string str)
        {
            throw new NotImplementedException();
        }

        public static int GuessKeyLength(string cypherText)
        {
            throw new NotImplementedException();
        }

        public static string GuessKey(string cypherText)
        {
            throw new NotImplementedException();
        }
    }
}
