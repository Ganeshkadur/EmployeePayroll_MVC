using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer.RequestModels
{
    public class EmployeeModel
    {
        
        [Required(ErrorMessage = "{0} should not be empty")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "First name start with Cap and Should have minimum 3 character")]
        [RegularExpression(@"^[A-Z]{1}[a-zA-Z ]{2,}$", ErrorMessage = "The Name is not valid....!")]

        [DataType(DataType.Text)]
        public string FullName { get; set; }
        public string ImagePath { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        [Required(ErrorMessage = "It is a required field")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Salary is not valid")]
        public decimal Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Notes { get; set; }

    }
}
