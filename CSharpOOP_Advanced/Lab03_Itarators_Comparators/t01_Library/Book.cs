using System;
using System.Collections.Generic;
using System.Text;

public class Book
{
    public Book(string title, int year, params string[] authors)
    {
        Title = title;
        Year = year;
        Authors = authors;
    }

    public string Title { get; set; }
    public int Year { get; set; }
    public IReadOnlyList<string> Authors { get; set; }

    public override string ToString()
    {
        string authors = "anonimous";
        if (Authors.Count > 0)
        {
            authors = string.Join(", ", Authors);           
        }
        
        return $"{Title} - {Year} - {authors}";
    }
}
