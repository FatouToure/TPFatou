using System;

namespace Cryptanalysis
{
    public class Caesar
    {
        private int key;

        public Caesar(int key)
        {
            this.key = key;
        }

        public string Encrypt(string msg)
        {
            string res = "";

            foreach (var c in msg)
            {
                res += Tools.RotChar(c, key);
            }

            return res;
        }

        public string Decrypt(string cypherText)
        {
            string res = "";

            foreach (var c in cypherText)
            {
                res += Tools.RotChar(c, -key);
            }

            return res;
        }

        public static int Maximum(int[] array)
        {
            int max = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[max] <= array[i])
                {
                    max = i;
                }
            }

            return max;
        }
        public static int GuessKey(string cypherText)
        {
            int[] hist = Tools.Histogram(cypherText);
            int max = Maximum(hist);
            
            int res = hist[max] - hist[4];

            return res;
        }
    }
}