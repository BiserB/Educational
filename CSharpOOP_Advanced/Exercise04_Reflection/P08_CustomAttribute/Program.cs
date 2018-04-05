
using System;

public class Program
{
    static void Main()
    { 
        Type targetType = typeof(TargetClass);

        var customAtributes = targetType.GetCustomAttributes(false);

        string author = "";
        int revision = 0;
        string desc = "";
        string[] reviewers =  new string[] { };

        foreach (var atribute in customAtributes)
        {
            InfoAttribute infoAtr = atribute as InfoAttribute;

            if (infoAtr != null)
            {
                author = infoAtr.Author;
                revision = infoAtr.Revision;
                desc = infoAtr.Description;
                reviewers = infoAtr.Reviewers;
            }
        }

        string input = Console.ReadLine();

        while (input != "END")
        {
            switch (input)
            {
                case "Author":
                    Console.WriteLine("Author: {0}", author);
                    break;
                case "Revision":
                    Console.WriteLine("Revision: {0}", revision);
                    break;
                case "Description":
                    Console.WriteLine("Class description: {0}", desc);
                    break;
                case "Reviewers":
                    string rev = string.Join(", ", reviewers);
                    Console.WriteLine("Reviewers: {0}", rev);
                    break;
            }

            input = Console.ReadLine();
        }
    }
}
