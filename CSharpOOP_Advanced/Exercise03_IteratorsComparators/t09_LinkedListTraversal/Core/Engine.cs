using System;
using System.Collections.Generic;


public class Engine
{
    private readonly IReader reader;
    private readonly IWriter writer;    
    private MyLinkedList<int> linkedList;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
        linkedList = new MyLinkedList<int>();
    }

    public void Run()
    {
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string[] data = Console.ReadLine().Split();
            int number = int.Parse(data[1]);

            switch (data[0])
            {
                case "Add":
                    linkedList.Add(number);
                    break;
                case "Remove":
                    linkedList.Remove(number);
                    break;                
            }
        }

        writer.WriteLine(linkedList.Count.ToString());

        string elements = string.Join(" ", linkedList);

        writer.WriteLine(elements);
    }

   
   
}