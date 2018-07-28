using BookLibrary.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.App.Models
{
    public class CustomDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            BookLoan loan = (BookLoan)validationContext.ObjectInstance;

            DateTime date2 = new DateTime(2000, 1, 1, 0, 0, 0);

            if (loan.DateOfLoan == null)
            {
                return new ValidationResult("Start Date is required.");
            }

            if (DateTime.Compare(loan.DateOfLoan, date2) < 0)
            {
                return new ValidationResult("Start Date must be after 01/01/2000");
            }

            if (loan.DateOfLoan > loan.DueDate)
            {
                return new ValidationResult("Start Date must be prior End Date.");
            }

            return ValidationResult.Success;
        }
    }
}