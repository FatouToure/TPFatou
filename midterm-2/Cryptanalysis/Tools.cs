using System;
using System.Collections.Generic;

namespace Cryptanalysis
{
    public static class Tools
    {
        public static int Modulus(int a, int b)
        {
            if (b < 0)
                b = -b;

            var mod = a % b;
            return mod < 0 ? b + mod : mod;
        }

        public static int LetterIndex(char c)
        {
            int ord = Convert.ToInt32(c);

            if (ord < 65 || ord > 122)
            {
                return -1;
            }
            else
            {
                if (ord <= 90)
                {
                    return ord - 65;
                }

                if (ord >= 97)
                {
                    return ord - 97;
                }

                return -1;
            }
        }

        public static char RotChar(char c, int n)
        {
            char letter = c;
            int nOrd = 0;
            int nAscii = 0;

            if (c < 65 || c > 122)
            {
                return c;
            }
            else
            {

                if (c >= 65 && c <= 90)
                {
                    nOrd = LetterIndex(c);
                    nAscii = Modulus(nOrd + n, 26);

                    letter = Convert.ToChar(nAscii + 65);
                }

                if (c >= 97 && c <= 122)
                {
                    nOrd = LetterIndex(c);
                    nAscii = Modulus(nOrd + n, 26);

                    letter = Convert.ToChar(nAscii + 97);
                }

                return letter;
            }
        }

        public static int[] Histogram(string str)
        {
            int[] index = new int[26];

            foreach (var c in str)
            {
                if (LetterIndex(c) != -1)
                {
                    index[LetterIndex(c)]++;
                }
            }

            return index;
        }

        public static string FilterLetters(string str)
        {
            string res = "";

            foreach (var c in str)
            {
                if (LetterIndex(c) != -1)
                {
                    res += c;
                }
            }

            return res;
        }

        public static string Extract(string str, int start, int step)
        {
            string res = "";

            if (step <= 0)
            {
                throw new ArgumentException("the step must be strictly bigger than zero.");
            }
            else
            {
                string temp = "";

                for (int i = 0; i < str.Length; i++)
                {
                    if (i >= start)
                    {
                        temp += str[i];
                    }
                }

                int j = 0;
                int l = temp.Length;

                while (j < l)
                {
                    if (Modulus(j,step) == 0)
                    {
                        res += temp[j];
                    }

                    j++;
                }
            }

            return res;
        }
    }
}
