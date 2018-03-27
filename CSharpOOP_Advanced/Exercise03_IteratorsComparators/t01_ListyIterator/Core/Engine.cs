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

        try
        {
            string command = reader.ReadLine();

            while (command != "END")
            {
                string result = "";

                switch (command)
                {
                    case "Move":
                        result = listy.Move().ToString();
                        writer.WriteLine(result);
                        break;

                    case "HasNext":
                        result = listy.HasNext().ToString();
                        writer.WriteLine(result);
                        break;

                    case "Print":
                        listy.Print();
                        break;

                    default:
                        throw new ArgumentException("Wrong command");
                }
                
                command = reader.ReadLine();
            }
        }
        catch (ArgumentException ae)
        {
            writer.WriteLine(ae.Message);
        }
        catch (InvalidOperationException ioe)
        {
            writer.WriteLine(ioe.Message);
        }

    }
}