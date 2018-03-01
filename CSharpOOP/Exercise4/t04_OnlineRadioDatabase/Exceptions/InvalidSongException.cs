using System;

public class InvalidSongException:Exception
{   
    public InvalidSongException(string message) : base(message)
    {
    }
}