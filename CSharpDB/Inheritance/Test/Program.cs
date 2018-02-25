using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculator.AreEqual("A","A"));

        }
    }
    public class Calculator
    {
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public static bool AreEqual<T>(T Value1, T Value2)
        {
            return Value1.Equals(Value2);
        }
    }

}
