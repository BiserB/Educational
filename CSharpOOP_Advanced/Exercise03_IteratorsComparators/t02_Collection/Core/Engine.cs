using System;
using System.Linq;

public class Engine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly ListyFactory factory;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
        factory = new ListyFactory();
    }

    public void Run()
    {
        string input = reader.ReadLine();
        string[] args = input.Split();
        string[] elements = args.Skip(1).ToArray();
        var listy = factory.Create(elements);


        string command = reader.ReadLine();

        while (command != "END")
        {
            string result = "";

            switch (command)
            {
                case "Move":
                    result = listy.Move().ToString();
                    break;

                case "HasNext":
                    result = listy.HasNext().ToString();
                    break;

                case "Print":
                    try
                    {
                        result = listy.Print();
                    }
                    catch (InvalidOperationException ioe)
                    {
                        result = ioe.Message;
                    }
                    break;

                case "PrintAll":
                    result = string.Join(" ", listy);
                    break;
                
            }

            if (result != "")
            {
                writer.WriteLine(result);
            }


            command = reader.ReadLine();
        }
       

    }
}