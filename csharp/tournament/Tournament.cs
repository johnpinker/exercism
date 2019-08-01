using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public static class Tournament
{   
    public class Record: IComparable<Record>, IEquatable<Record>{
        private string _teamName;
        public string TeamName {
            get => _teamName;
            set => _teamName = value;
        }
        private int _mp;
        public int mp {
            get => _mp;
            set => _mp = value;
        }
        private int _w;
        public int w {
            get => _w;
            set => _w = value;
        }
        private int _d;
        public int d {
            get => _d;
            set => _d = value;
        }
        private int _l;
        public int l {
            get => _l;
            set => _l = value;
        }
        private int _p;
        public int p {
            get => _p;
            set => _p = value;
        }

        public bool Equals(Record r)
        {
            if (this._teamName == r._teamName)
                return true;
            else 
                return false;
        }

        public int CompareTo(Record r) 
        {
            if (r.p == this._p)
            {
                return this.TeamName.CompareTo(r.TeamName);
            }
            else if (this._p > r.p)
            {
                return -1;
            }
            else 
                return 1;
        }


        public void RecordWin()
        {
            this._p = this._p +3;
            this._w++;
            this._mp++;
        }

        public void RecordLoss()
        {
            this._l++;
            this._mp++;
        }

        public void RecordDraw()
        {
            this._mp++;
            this._d++;
            this._p++;
        }
    }
    
    private static List<Record> games;

    public static void Tally(Stream inStream, Stream outStream)
    {
        games =  new List<Record>();
        using (StreamReader sr = new StreamReader(inStream))
        {
            while (!sr.EndOfStream)
            {
                string tmpStr;
                tmpStr = sr.ReadLine();
                string[] entries = tmpStr.Split(";");
                Record team1 = GetTeam(entries[0]);
                Record team2 = GetTeam(entries[1]);
                switch (entries[2])
                {
                    case "win":
                        team1.RecordWin();
                        team2.RecordLoss();
                        break;
                    case "loss":
                        team1.RecordLoss();
                        team2.RecordWin();
                        break;
                    case "draw":
                        team1.RecordDraw();
                        team2.RecordDraw();
                        break;

                }
                UpdateTeam(team1);
                UpdateTeam(team2);
            }
        }

        using (StreamWriter sw = new StreamWriter(outStream))
        {
        sw.Write("Team                           | MP |  W |  D |  L |  P");
        if (games.Count != 0)
            sw.WriteLine("");
        games.Sort();
        for (int i = 0; i< games.Count; i++)
        {
            Record r = games[i];
            sw.Write($"{r.TeamName,-30} | {r.mp,2} | {r.w,2} | {r.d,2} | {r.l,2} | {r.p,2}");
            if (i < games.Count-1)
                sw.WriteLine("");
        }
        sw.Flush();
        }
    }

    private static Record GetTeam(string name)
    {
        foreach (Record r in games)
        {
            if (r.TeamName == name)
            {
                return r;
            }
        }
        Record newRecord = new Record();
        newRecord.TeamName = name;
        games.Add(newRecord);
        return newRecord;
    }

    private static void UpdateTeam(Record newRecord)
    {
        for (int i=0; i < games.Count; i++) {
            if (games[i].TeamName == newRecord.TeamName)
                games[i] = newRecord;
        }
    }
}
