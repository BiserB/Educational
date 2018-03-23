using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }
        
        public override string ToString()
        {
            string result = base.ToString() + Environment.NewLine;
            result += (string.Join(Environment.NewLine, Documents));
            return result;
        }
    }
}
