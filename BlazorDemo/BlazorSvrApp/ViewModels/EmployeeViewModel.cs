using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace BlazorSvrApp.ViewModels
{
    public class EmployeeViewModel
    {
        [Required]
        [Display(Name = "Employee ID")]
        public int EmployeeID { get; set; }


        [Required]
        [MaxLength(60)]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }


        [Required]
        [Display(Name = "Salary")]
        [Range(minimum: 0.00, maximum: 100000, ErrorMessage = "Salary has to be between 0.00 and 100,000!")]
        public Decimal Salary { get; set; }


        [Required]
        [Display(Name = "Is Enabled")]
        public bool IsEnabled { get; set; }
    }
}
