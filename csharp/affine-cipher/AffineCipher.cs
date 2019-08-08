using System;
using System.Collections.Generic;
using System.Linq;

public static class AffineCipher
{
    public static string Encode(string plainText, int a, int b)
    {
        
        string retStr = "";
        int mmi = MMI(a);
        if (gcd(a, 26) != 1)
            throw new ArgumentException();
        string lowered = plainText.ToLower();
        lowered = new string(lowered.Where(s => char.IsLetterOrDigit(s)).ToArray());
        char[] sc = lowered.Select( s => char.IsDigit(s) ? s :
            (char)(((a * (s - 'a') + b)%26) + 'a')
        ).ToArray();
        for (int i=0; i<sc.Length; i++)
        {
            retStr += ((i)%5) == 0 && i !=0 ? $" {sc[i].ToString()}": sc[i].ToString();
        }
        return retStr;
    }

    public static string Decode(string cipheredText, int a, int b)
    {
        
        string cleanString = new string(cipheredText.Where(s => char.IsLetterOrDigit(s)).ToArray());
        int mmi = MMI(a);
        int tmpInt = 0;
        if (gcd(a, 26) != 1)
            throw new ArgumentException();
        char proc(char c)
        {
            if (char.IsDigit(c)) return c;
            tmpInt = (mmi*(c2i(c)-b))%26;
            tmpInt += tmpInt < 0 ? 26 : 0;
            return i2c(tmpInt);
        }
        char[] sc = cleanString.Select( s => proc(s)).ToArray();
        return new String(sc);
    }

    private static int c2i(char c) => c-'a';
    private static char i2c(int i) => (char)(i+'a');
    public static int MMI(int a)
    {
        int newA = a % 26;
        for (int i=1; i<= 26; i++ )
        {
            if ((newA*i)% 26 == 1)
                return i;
        }
        return 1;
    }

    public static int gcd(int a, int b)
    {
        List<int> alist = new List<int>();
        List<int> blist = new List<int>();
        List<int> clist = new List<int>();
        for (int i=1; i < (a > b ? a : b); i++)
        {
            if (a%i == 0)
                alist.Add(i);
            if (b%i == 0)
                blist.Add(i);
        }
        for (int i=0; i< alist.Count; i++)
            for (int j=0; j< blist.Count; j++)
                if (alist[i] == blist[j])
                    clist.Add(alist[i]);
        return clist.OrderByDescending(s => s).Max();

        
    }
}
