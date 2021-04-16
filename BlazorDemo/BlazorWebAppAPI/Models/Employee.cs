using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Good for educating which is additionally added
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace BlazorWebAppAPI.Models
{

   //[Table("Employees", Schema = "Department")] ---> With Schema
    //Having more than one schema could hinder performance speed. Not good for small application
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(60)]
        public string EmployeeName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]//Helps to change field type to smalldatetime
        //SmallDateTime is number value actually, like Excel
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DefaultValue(0.0)]
        public decimal Salary { get; set; }

        [Required]
        [DefaultValue(true)]
        public Boolean IsEnabled { get; set; }
    }
}
