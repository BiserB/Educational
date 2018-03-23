﻿using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        int integer = 5;

        Box<int> intBox = new Box<int>();
        Box<double> decBox = new Box<double>();

        intBox.Add(integer);
        intBox.Add(++integer);
        intBox.Add(++integer);
        decBox.Add(integer);

        Console.WriteLine(intBox.Count);

        Console.WriteLine(intBox.Remove());
    }
}
