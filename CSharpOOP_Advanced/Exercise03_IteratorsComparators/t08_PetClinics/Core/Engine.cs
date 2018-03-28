using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly ClinicManager manager;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
        this.manager = new ClinicManager();
    }

    public void Run()
    {
        CommandDispatcher();
    }

    private void CommandDispatcher()
    {
        int count = int.Parse(Console.ReadLine());

        while (count > 0)
        {
            string[] args = Console.ReadLine().Split();

            string command = args[0];

            if (command == "Create")
            {
                command = command + " " + args[1];
            }

            try
            {
                switch (command)
                {
                    case "Create Pet":
                        manager.CreatePet(args);
                        break;
                    case "Create Clinic":
                        manager.CreateClinic(args);
                        break;
                    case "Add":
                        writer.WriteLine(manager.AddPet(args).ToString());
                        break;
                    case "Release":
                        writer.WriteLine(manager.Release(args).ToString());
                        break;
                    case "HasEmptyRooms":
                        writer.WriteLine(manager.HasEmptyRooms(args).ToString());
                        break;
                    case "Print":                        
                        writer.WriteLine(manager.Print(args));
                        break;
                    default:
                        throw new ArgumentException("Wrong command!");
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

            count--;
        }
    }
   
}