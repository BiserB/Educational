using BookLibrary.Models;
using System.Collections.Generic;

namespace BookLibrary.ViewModels

{
    public class AuthorDetailsViewModel
    {        
        public string Name { get; set; }

        public List<(int, string, string)> Books { get; set; }
    }
}