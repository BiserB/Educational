using BookLibrary.App.Auxiliary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.App.Models.BindingModels
{
    public class AddLoanBindingModel
    {
        public AddLoanBindingModel()
        {
            this.Borrowers = new List<MinInfo>();
            this.Items = new List<MinInfo>();
        }

        public int BorrowerId { get; set; }

        public int ItemId { get; set; }

        [Required(ErrorMessage = "You have to specify a date.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1/1/2001", "1/1/2020")]
        public DateTime DateOfLoan { get; set; }

        [Required(ErrorMessage = "You have to specify a date.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1/1/2001", "1/1/2020")]
        [DateAfter("DateOfLoan")]
        public DateTime DueDate { get; set; }

        public List<MinInfo> Borrowers;

        public List<MinInfo> Items;
    }
}