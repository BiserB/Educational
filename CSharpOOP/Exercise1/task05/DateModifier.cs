using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;


public class DateModifier
{    
    public int Difference(string date1, string date2)
    {
        //string[] s = { " ", ",", "/", ":", ".", "\\", ";" };
        //string[] d1 = date1.Split(s, StringSplitOptions.RemoveEmptyEntries); 
        //string[] d2 = date2.Split(s, StringSplitOptions.RemoveEmptyEntries);
        CultureInfo provider = CultureInfo.InvariantCulture;
        DateTime date_1 = DateTime.ParseExact(date1,"yyyy MM dd", provider);
        DateTime date_2 = DateTime.ParseExact(date2, "yyyy MM dd", provider);
       
        int daydiff = Math.Abs((int)((date_1 - date_2).TotalDays));
        return daydiff;
    }    

}
 
