using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace Employee_Repository.Entities
{
    public class Employee
    {
        
        public int EmployeeId { get; set; } //primary key
        [Required(ErrorMessage = "{0} should not be empty")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "First name start with Cap and Should have minimum 3 character")]
        [RegularExpression(@"^[A-Z]{1}[a-zA-Z ]{2,}$", ErrorMessage = "First name is not valid")]

        [DataType(DataType.Text)]
        public string FullName {  get; set; }
        [Required(ErrorMessage = "It is a required field")]
        public string ImagePath {  get; set; }
        [Required(ErrorMessage = "It is a required field")]
        public string Gender {  get; set; }
        [Required(ErrorMessage = "It is a required field")]
        public string Department {  get; set; }
        [Required(ErrorMessage = "It is a required field")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Salary is not valid")]
        public decimal Salary {  get; set; }
        [Required(ErrorMessage = "It is a required field")]
        public DateTime StartDate {  get; set; }
        [Required(ErrorMessage = "It is a required field")]
        public string Notes {  get; set; }  

     
    }
}
