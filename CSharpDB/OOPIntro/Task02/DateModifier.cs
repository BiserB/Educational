using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DateModifier
{
    private string date1;
    private string date2;

    public string Date1
    {
        get { return this.date1; }
        set { this.date1 = value; }
    }  
    public string Date2
    {
        get { return this.date2; }
        set { this.date2 = value; }
    }
    public DateModifier(string date1, string date2)
    {
        this.Date1 = date1;
        this.Date2 = date2;
    }

    public int CalculateDiff()
    {        
        DateTime d1 = DateTime.ParseExact(this.date1, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
        DateTime d2 = DateTime.ParseExact(this.date2, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
        int days = (d1 - d2).Days;
        
        return Math.Abs(days);
    }

}
