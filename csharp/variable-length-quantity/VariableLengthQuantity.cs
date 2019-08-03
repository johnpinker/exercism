using System;
using System.Collections.Generic;

public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers)
    {
        List<uint> retVal = new List<uint>();
        foreach( uint i in numbers)
        {
            uint[] tmpArray = EncodeSingleInt(i);
            foreach (uint t in tmpArray) {
                retVal.Add(t);
            }
        }
        return retVal.ToArray();
    }

    private static uint[] EncodeSingleInt(uint toConvert)
    {
        List<uint> digitList = new List<uint>();
        List<uint> tmpList = new List<uint>();
        uint tmpDigit = toConvert;
        tmpList.Add(GetLast7Bits(tmpDigit));
        tmpDigit >>= 7;
        
        while (tmpDigit != 0)
        {
            tmpList.Add(GetLast7Bits(tmpDigit));
            tmpDigit >>= 7;
        }
        for (int j= tmpList.Count-1; j>= 0; j--)
        {
            if (j != 0)
                digitList.Add(tmpList[j] | 0b1000_0000);
            else digitList.Add(tmpList[j]);
        }
        return digitList.ToArray();
    }

    public static uint GetLast7Bits(uint toConvert) {
        return toConvert & 0x0000007Fu;
    }
    public static uint[] Decode(uint[] bytes)
    {
        List<uint> retList = new List<uint>();
        List<uint> singleList = new List<uint>();
        if ((bytes[bytes.Length-1] & 0b1000_0000) == 0b1000_0000)
            throw new InvalidOperationException();
        foreach (uint u in bytes)
        {
            
            if ((u & 0b1000_0000) == 0b1000_0000)
            {
                singleList.Add(u);
            }
            else 
            {
                singleList.Add(u);
                retList.Add(DecodeSingleDigit(singleList.ToArray()));
                singleList.Clear();
            }
        }
        return retList.ToArray();
    }

    public static uint DecodeSingleDigit(uint[] digitList)
    {
        uint tmpInt = 0;
        for (int i = 0; i < digitList.Length; i++)
        {
            if ((digitList[i] & 0b1000_0000) == 0b1000_0000)
            {
                digitList[i] &= 0b0111_1111;
                digitList[i] <<= ((digitList.Length-i-1) * 7);
            }
            tmpInt |= digitList[i];
        }
        return tmpInt;
    }

}