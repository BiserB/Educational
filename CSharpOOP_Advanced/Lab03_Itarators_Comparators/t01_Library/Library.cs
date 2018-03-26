
using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    private List<Book> books;

    public Library(params Book[] books)
    {
        this.books = new List<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        int currentIndex;

        private readonly List<Book> books;

        public LibraryIterator(List<Book> books)
        {
            this.Reset();
            this.books = books;
        }        

        public Book Current
        {
            get { return this.books[currentIndex]; }
        }

        object IEnumerator.Current
        {
            get { return this.Current; }
        }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {            
            if (currentIndex + 1 < books.Count)
            {
                currentIndex++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }
    }


}
