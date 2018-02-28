using System;

namespace t9
{
    class Program
    {
        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFibonacci
    {
        class Program
        {
            static void Main(string[] args)
            {
                int num = int.Parse(Console.ReadLine());
                Stack<long> register = new Stack<long>();
                long a = 0;
                long b = 1;
                register.Push(1);
                for (int i = 1; i < num; i++)
                {
                    register.Push(a + b);
                    a = b;
                    b = register.Peek();
                }
                Console.WriteLine(register.Peek());
            }
        }
    }

}
}
