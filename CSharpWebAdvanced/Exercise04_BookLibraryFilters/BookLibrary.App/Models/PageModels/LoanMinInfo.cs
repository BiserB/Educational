namespace BookLibrary.App.Models
{
    public class LoanMinInfo
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public int ItemId { get; set; }

        public string ItemTitle { get; set; }

        public string DateOfLoan { get; set; }

        public string DueDate { get; set; }

        public bool IsReturned { get; set; }

        public bool IsOverdue { get; set; }
    }
}