using System;
using System.Collections.Generic;
using System.Linq;

public static class SecretHandshake
{
 
        public static readonly int Wink = 0x00000001;
        private static readonly int DoubleBlink = 0x00000002;
        private static readonly int CloseEyes = 0x00000004;
        private static readonly int Jump = 0x00000008;
        private static readonly int Reverse = 0x00000010;

    public static string[] Commands(int commandValue)
    {
        List<string> retList = new List<string>();
        if ((commandValue & Wink) == Wink)
            retList.Add("wink");
        if ((commandValue & DoubleBlink) == DoubleBlink)
            retList.Add("double blink");
        if ((commandValue & CloseEyes) == CloseEyes)
            retList.Add("close your eyes");
        if ((commandValue & Jump) == Jump)
            retList.Add("jump");
        if ((commandValue & Reverse) == Reverse)
            retList.Reverse();
        return retList.ToArray();
    }
}
