using System;
using System.Collections.Generic;
public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        char[] tmpStr = nucleotide.ToCharArray();
        for (int i=0; i<tmpStr.Length; i++)
        {
            switch (tmpStr[i])
            {
                case 'G' :
                    tmpStr[i] = 'C';
                    break;
                case 'C':
                    tmpStr[i] = 'G';
                    break;
                case 'T':
                    tmpStr[i] = 'A';
                    break;
                case 'A':
                    tmpStr[i] = 'U';
                    break;
                default:
                    throw new ArgumentException();
            }
        }
        return new string(tmpStr);
    }
}