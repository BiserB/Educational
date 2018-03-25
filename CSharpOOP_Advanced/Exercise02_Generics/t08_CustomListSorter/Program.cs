using System;


class Program
{
    static void Main(string[] args)
    {
        var customList = new CustomList<string>();

        try
        {
            CommandDispatcher(customList);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }

    private static void CommandDispatcher(CustomList<string> customList)
    {
        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] data = input.Split();
            string command = data[0];
            Func<int> getIndex = () => int.Parse(data[1]);
            Func<int> getIndex2 = () => int.Parse(data[2]);
            string result = "";

            switch (command)
            {
                case "Add":
                    customList.Add(data[1]);
                    break;

                case "Remove":
                    customList.Remove(getIndex());
                    break;

                case "Contains":
                    result = (customList.Contains(data[1])).ToString();
                    break;

                case "Swap":
                    customList.Swap(getIndex(), getIndex2());
                    break;

                case "Greater":
                    result = (customList.CountGreaterThan(data[1])).ToString();
                    break;

                case "Max":
                    result = (customList.Max()).ToString();
                    break;

                case "Min":
                    result = (customList.Min()).ToString();
                    break;

                case "Print":
                    result = (customList.PrintAll()).ToString();
                    break;

                case "Sort":
                    customList.Sort();
                    break;

                default:
                    throw new ArgumentException("Invalid command!");
            }

            if (result != "")
            {
                Console.WriteLine(result);
            }

            input = Console.ReadLine();
        }
    }
}