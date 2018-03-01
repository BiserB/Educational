

using System;
using System.Text;

public class Book
{
    private readonly int MIN_LENGTH = 3;
    private string author;
    private string title;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        Author = author;
        Title = title;
        Price = price;
    }

    public string Author
    {
        get { return author; }
        set
        {            
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Author not valid!");
            }
            string[] names = value.Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
            if (names.Length > 1 && Char.IsDigit(names[1][0]) )
            {
                throw new ArgumentException("Author not valid!");
            }
            author = value;
        }
    }
    public string Title
    {
        get { return title; }
        set
        {
            if (String.IsNullOrWhiteSpace(value) || value.Length < MIN_LENGTH)
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }
    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0 )
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("Type: ").AppendLine(this.GetType().Name)
            .Append("Title: ").AppendLine(this.Title)
            .Append("Author: ").AppendLine(this.Author)
            .Append("Price: ").Append($"{this.Price:f2}")
            .AppendLine();

        return sb.ToString();
    }

}
