using System.Collections.Generic;

public interface ICommandInterpreter
{
    ICommand ProcessCommand(IList<string> args);
}