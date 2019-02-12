using System.Collections.Generic;

namespace BookLibrary.Models
{
    public class Status
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}