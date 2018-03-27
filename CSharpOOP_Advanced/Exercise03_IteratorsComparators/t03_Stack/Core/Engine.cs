using System;
using System.Linq;

public class Engine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private CustomStack<string> stack;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
        stack = new CustomStack<string>();
    }

    internal void Run()
    {
        try
        {
            CommandDispatcher();
        }
        catch (ArgumentException ae)
        {
            writer.WriteLine(ae.Message);  
        }
        catch (InvalidOperationException ioe)
        {
            writer.WriteLine(ioe.Message);
        }

        for (int i = 0; i < 2; i++)
        {
            foreach (var item in stack)
            {
                writer.WriteLine(item);
            }
        }
        
    }

    private void CommandDispatcher()
    {
        string input = reader.ReadLine();

        while (input != "END")
        {
            string[] data = input.Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries );
            string command = data.First();

            switch (command)
            {
                case "Push":
                    string[] elements = data.Skip(1).ToArray();
                    foreach (var element in elements)
                    {
                        stack.Push(element);
                    }
                    break;

                case "Pop":
                    stack.Pop();
                    break;

                default:
                    throw new ArgumentException("Wrong command!");
            }

            input = reader.ReadLine();
        }
    }
}