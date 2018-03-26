using System;
using System.Collections.Generic;
using System.Text;

public class Book : IComparable<Book>
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

    public int CompareTo(Book other)
    {
        if (this.Year.CompareTo(other.Year) != 0)
        {
            return this.Year.CompareTo(other.Year);
        }
        else
        {
            return (this.Title.CompareTo(other.Title));
        }
    }    

    public override string ToString()
    {        
        return $"{Title} - {Year}";
    }
}
