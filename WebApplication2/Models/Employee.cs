using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [FirstNameValidation]
        public string FirstName { get; set; }

        [StringLength(15,ErrorMessage ="Last Name length shold not be greater than 15 letters.")]
        public string LastName { get; set; }

        [Range(10000,50000)]
        public int? Salary { get; set; }
    }

    public class FirstNameValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null) //Checking for empty value
            {
                return new ValidationResult("Please Provide First Name");
            }
            else
            {
                if(value.ToString().Contains("@"))
                {
                    return new ValidationResult("First Name should Not Contain @");
                }
            }
            return ValidationResult.Success;
        }
    }

}