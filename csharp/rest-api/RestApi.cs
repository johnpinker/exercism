using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

public class RestApi
{
    User[] db { get; set;}
    public RestApi(string database)
    {
        User[] tmpDb = JsonConvert.DeserializeObject<User[]>(database);
        this.db = tmpDb;
    }

    public string Get(string url, string payload = null)
    {
        string tmpStr = "";
        if (url.Contains("/users"))
        {   if (payload == null)
                tmpStr = JsonConvert.SerializeObject(this.db.Select(s => s));
            else 
            {
                Dictionary<string, List<string>> o = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(payload);
                tmpStr = JsonConvert.SerializeObject(this.db.Where(s => o["users"].Contains(s.name)));
            }
        }
        return tmpStr;
    }

    public string Post(string url, string payload)
    {
        if (url.Contains("/add"))
        {
            Dictionary<string, string> o = JsonConvert.DeserializeObject<Dictionary<string, string>>(payload);
            string userName = o["user"];
            this.db = this.db.Append(new User() {name = userName}).ToArray();
            string tmpStr = JsonConvert.SerializeObject(this.db.Where(s => s.name == userName).FirstOrDefault());
            return tmpStr;
        }
        else if (url.Contains("/iou"))
        {
            Dictionary<string, string> o = JsonConvert.DeserializeObject<Dictionary<string, string>>(payload);
            string lender = o["lender"];
            string borrower = o["borrower"];
            double amount = double.Parse(o["amount"]);
            this.db.Where(s => s.name==lender).FirstOrDefault().LoanMoney(borrower, amount);
            this.db.Where(s => s.name==borrower).FirstOrDefault().BorrowMoney(lender, amount);
            return JsonConvert.SerializeObject(this.db.Where(s => s.name == lender || s.name == borrower));
        }
        return null;
    }
}

public class User {
    [JsonProperty(Order = 1)]
    public string name { get; set; }
    [JsonProperty(Order = 2)]
    public SortedDictionary<string, double> owes = new SortedDictionary<string, double>();
    [JsonProperty(Order = 3)]
    public Dictionary<string, double> owed_by  = new Dictionary<string, double>();
    double _balance;
    [JsonProperty(Order = 4)]
    public double balance {
        get
        {
            double? bal = this.owed_by.Select(s => s.Value).Sum();
            double? bal2 = this.owes.Select(s => s.Value).Sum();
            _balance = (bal ?? 0) - (bal2 ?? 0);
            return _balance;
        }
        set { _balance = value;}
    }

    public void LoanMoney(string person, double amount)
    {
        if (owes.Keys.Contains(person)) // subtract money owed
        {
            owes[person] -= amount;
            if (owes[person] == 0) owes.Remove(person);
            else if (owes[person] < 0)
            {
                this.owed_by.Add(person, Math.Abs(owes[person]));
                owes.Remove(person);
            }
        }
        else if (owed_by.Keys.Contains(person)) owed_by[person] += amount;
        else owed_by.Add(person, amount);
    }

    public void BorrowMoney(string person, double amount)
    {
        if (owed_by.Keys.Contains(person)) // they owe you money so sub
        {
            owed_by[person] -= amount;
            if (owed_by[person] == 0) owed_by.Remove(person);
            else if (owed_by[person] < 0)
            {
                this.owes.Add(person, Math.Abs(owed_by[person]));
                owed_by.Remove(person);
            }
        }
        else if (owes.Keys.Contains(person)) owes[person] += amount;
        else owes.Add(person, amount);
    }

}
