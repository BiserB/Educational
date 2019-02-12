using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.App.Models
{
    public class LoanMinInfo
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public string BookTitle { get; set; }

        public string DateOfLoan { get; set; }

        public string DueDate { get; set; }

        public bool IsReturned { get; set; }
    }
}
