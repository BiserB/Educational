using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


public class Book              // title, author and price.
{
    private string title;
    private string author;
    private decimal price;

    public Book( string author, string title, decimal price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }

    public string Title
    {
        get { return this.title; }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    public string Author
    {
        get { return this.author; }
        private set
        {
            string authorCheck = @"[\w]+ [0-9][\w]+";
            if (Regex.IsMatch(value, authorCheck))
            {
                throw new ArgumentException("Author not valid!");
            }
            this.author = value;
        }
    }

    public decimal Price
    {
        get { return this.price; }
        protected set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }



    public override string ToString()
    {
        object N = Environment.NewLine;
        string output = $"Type: {this.GetType().Name}{N}" +
                        $"Title: {this.title}{N}" +
                        $"Author: {this.author}{N}" +
                        $"Price: {this.price:f2}";
        return output;
    }


}

