using System;
using System.Text;

namespace L4
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            if (num == 1)
            {
                Console.WriteLine(1);
                Environment.Exit(0);
            }
            

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1");
            sb.AppendLine("1 1");
            UInt64[] previous = new UInt64[] {1, 1, 0};
            
            for (int i = 2; i < num; i++)
            {
                UInt64[] arr = new UInt64[i + 1];
                arr[0] = 1;
                arr[i] = 1;
                for (int j = 1; j < i; j++)
                {
                    arr[j] = previous[j - 1] + previous[j];                    
                }

                sb.AppendLine(String.Join(" ", arr));
                                               
                previous = arr;
            }
            string result = sb.ToString();
            Console.WriteLine(result);
        }
    }
}
