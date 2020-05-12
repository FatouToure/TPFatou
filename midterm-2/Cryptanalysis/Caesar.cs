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
    
    public static int GuessKey(string cypherText)
    {
        throw new NotImplementedException();
    }
}
}