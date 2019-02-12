using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.App.Models
{
    public class LoanInfo
    {
        public int Id { get; set; }

        public int BorrowerId { get; set; }
        
        public string BorrowerName { get; set; }

        public int BookId { get; set; }

        public string BookTitle { get; set; }

        public string DateOfLoan { get; set; }

        public string DueDate { get; set; }
        
        public string Status { get; set; }

        public bool IsReturned { get; set; }
                
    }
}
