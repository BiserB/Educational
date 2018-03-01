// Create a method which receives as a parameter another Rectangle,
// checks if the two rectangles intersect and returns true or false.

using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        try
        {
            List<Rectangle> list = new List<Rectangle>();
            string[] input = Console.ReadLine().Split(new string[] { " "}, StringSplitOptions.RemoveEmptyEntries);
            int num = int.Parse(input[0]);
            int checks = int.Parse(input[1]);

            for (int i = 0; i < num; i++)
            {
                string[] data = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string id = data[0];
                double width = double.Parse(data[1]);
                double height = double.Parse(data[2]);
                double x = double.Parse(data[3]);
                double y = double.Parse(data[4]);

                var newRectangle = new Rectangle(id, width, height, x, y);
                list.Add(newRectangle);
            }

            
            for (int i = 0; i < checks; i++)
            {
                string[] data = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string id1 = data[0];
                string id2 = data[1];
                var rec1 = list.FirstOrDefault(r => r.Id == id1);
                var rec2 = list.FirstOrDefault(r => r.Id == id2);

                Console.WriteLine(rec1.Intersect(rec2).ToString().ToLower());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); ;
        }
    }
}

