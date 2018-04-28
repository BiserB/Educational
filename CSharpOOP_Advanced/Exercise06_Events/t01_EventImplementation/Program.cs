using System;

namespace t01_EventImplementation
{
    public class Program
    {
        static void Main()
        {
            var dispatcher = new Dispatcher();
            var handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;
            
            string input = Console.ReadLine();

            while (input != "End")
            {
                dispatcher.SetNewName(input);

                input = Console.ReadLine();
            }
        }
    }
}
