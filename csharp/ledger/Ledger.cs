﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class LedgerEntry
{
   public LedgerEntry(DateTime date, string desc, decimal chg)
   {
       Date = date;
       Desc = desc;
       Chg = chg;
   }

   public DateTime Date { get; }
   public string Desc { get; }
   public decimal Chg { get; }
}

public static class Ledger
{
   public static LedgerEntry CreateEntry(string date, string desc, int chng)
   {
       return new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0m);
   }

   private static CultureInfo CreateCulture(string cur, string loc)
   {
       string curSymb = null;
       int curNeg = 0;
       string datPat = null;

       if ((cur != "USD" && cur != "EUR") && (loc != "nl-NL" && loc != "en-US"))
       {
           throw new ArgumentException("Invalid currency");
       }
       else
       {
           /* if (loc != "nl-NL" && loc != "en-US")
           {
               throw new ArgumentException("Invalid currency");
           }*/

           if (cur == "USD")
           {
               if (loc == "en-US")
               {
                   curSymb = "$";
                   datPat = "MM/dd/yyyy";
               }
               else if (loc == "nl-NL")
               {
                   curSymb = "$";
                   curNeg = 12;
                   datPat = "dd/MM/yyyy";
               }
           }

           if (cur == "EUR")
           {
               if (loc == "en-US")
               {
                   curSymb = "€";
                   datPat = "MM/dd/yyyy";
               }
               else if (loc == "nl-NL")
               {
                   curSymb = "€";
                   curNeg = 12;
                   datPat = "dd/MM/yyyy";
               }
           }
       }

       var culture = new CultureInfo(loc);
       culture.NumberFormat.CurrencySymbol = curSymb;
       culture.NumberFormat.CurrencyNegativePattern = curNeg;
       culture.DateTimeFormat.ShortDatePattern = datPat;
       return culture;
   }

   private static string PrintHead(string loc)
   {
       switch (loc)
       {
           case "en-US": return "Date       | Description               | Change       ";
           case "nl-NL": return "Datum      | Omschrijving              | Verandering  ";
           default: throw new ArgumentException("Invalid locale");
       }
       /*
       if (loc == "en-US")
       {
           return "Date       | Description               | Change       ";
       }

        else
       {
           if (loc == "nl-NL")
           {
               return "Datum      | Omschrijving              | Verandering  ";
           }
           else
           {
               throw new ArgumentException("Invalid locale");
           }
       }
       */
   }

      /* 
   private static string Date(IFormatProvider culture, DateTime date) => date.ToString("d", culture);

   private static string Description(string desc)
   {
 
       if (desc.Length > 25)
       {
           var trunc = desc.Substring(0, 22);
           trunc += "...";
           return trunc;
       }

       return desc;
       
   }

    private static string Change(IFormatProvider culture, decimal cgh)
   {
       return cgh < 0.0m ? cgh.ToString("C", culture) : cgh.ToString("C", culture) + " ";
   }
*/

   private static string PrintEntry(IFormatProvider culture, LedgerEntry entry)
   {
       var formatted = "";
       //var date = Date(culture, entry.Date);
       var date = entry.Date.ToString("d", culture);
       //var description = Description(entry.Desc);
       var description = entry.Desc.Length > 25 ? entry.Desc.Substring(0,22) + "..." : entry.Desc;
       //var change = Change(culture, entry.Chg);
       var change = entry.Chg < 0.0m ? entry.Chg.ToString("C", culture) : entry.Chg.ToString("C", culture) + " ";

       formatted += date;
       formatted += " | ";
       formatted += string.Format("{0,-25}", description);
       formatted += " | ";
       formatted += string.Format("{0,13}", change);

       return formatted;
   }

/* 
   private static IEnumerable<LedgerEntry> sort(LedgerEntry[] entries)
   {
       var neg = entries.Where(e => e.Chg < 0).OrderBy(x => x.Date + "@" + x.Desc + "@" + x.Chg);
       var post = entries.Where(e => e.Chg >= 0).OrderBy(x => x.Date + "@" + x.Desc + "@" + x.Chg);

       var result = new List<LedgerEntry>();
       result.AddRange(neg);
       result.AddRange(post);

       return result;
   }
*/
   public static string Format(string currency, string locale, LedgerEntry[] entries)
   {
       var formatted = "";
       formatted += PrintHead(locale);

       var culture = CreateCulture(currency, locale);

        foreach (LedgerEntry le in from e in entries orderby e.Chg, e.Date select e)
        {
            formatted += "\n" + PrintEntry(culture, le);
        }
        /* 
       if (entries.Length > 0)
       {
           //var entriesForOutput = sort(entries);
           var entriesForOutput = from e in entries
                                orderby e.Chg, e.Date
                                select e;

           for (var i = 0; i < entriesForOutput.Count(); i++)
           {
               formatted += "\n" + PrintEntry(culture, entriesForOutput.Skip(i).First());
           }
       }
*/
       return formatted;
   }
}
