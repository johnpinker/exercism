using System;

public class SimpleCipher
{
    public SimpleCipher()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        Random r = new Random();
        for (int i=0; i< 10; i++)
            sb.Append(i2c(r.Next(25)));
        Key = sb.ToString();
    }

    public SimpleCipher(string key)
    {
        Key = key;
    }
    
    public string Key 
    {
        get; private set;
    }

    public string Encode(string plaintext)
    {
        char[] newString = new char[plaintext.Length];
        for (int i=0; i<plaintext.Length; i++)
            newString[i] = i2c((c2i(plaintext[i]) + c2i(Key[i%Key.Length]))%26);
        return new string(newString);
    }

    public string Decode(string ciphertext)
    {
        char[] newString = new char[ciphertext.Length];
        for (int i=0; i<ciphertext.Length; i++)
        {
            newString[i] = i2c((c2i(ciphertext[i]) - c2i(Key[i%Key.Length])));
            if (newString[i] < 'a')
                newString[i] = i2c(c2i(newString[i])+26);
        }
        return new string(newString);
    }

    private int c2i(char c) => (c-'a');
    private char i2c(int i) => (char)(i + 'a');
}