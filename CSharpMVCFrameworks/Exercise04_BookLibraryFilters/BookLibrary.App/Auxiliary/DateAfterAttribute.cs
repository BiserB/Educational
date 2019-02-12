using System;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.App.Auxiliary
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DateAfterAttribute : ValidationAttribute
    {
        private readonly string nameOfDateField;

        public DateAfterAttribute(string nameOfDateField)
        {
            this.nameOfDateField = nameOfDateField;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value == null)
            {
                return new ValidationResult("Value can not be null!");
            }

            DateTime dueDate = (DateTime)value;

            var property = context.ObjectType.GetProperty(nameOfDateField);

            if (property == null)
            {
                return new ValidationResult("Invalid property name!");
            }

            var dateOfLoan = (DateTime)property.GetValue(context.ObjectInstance, null);

            if (dateOfLoan > dueDate)
            {
                return new ValidationResult("Due date must be after date of loan!");
            }

            return ValidationResult.Success;
        }
    }
}