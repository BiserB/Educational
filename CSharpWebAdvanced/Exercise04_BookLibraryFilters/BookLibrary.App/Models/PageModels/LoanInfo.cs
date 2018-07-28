namespace BookLibrary.App.Models
{
    public class LoanInfo
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public int BorrowerId { get; set; }

        public string BorrowerName { get; set; }

        public int ItemId { get; set; }

        public string ItemTitle { get; set; }

        public string DateOfLoan { get; set; }

        public string DueDate { get; set; }

        public string Status { get; set; }

        public bool IsReturned { get; set; }
    }
}