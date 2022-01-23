using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zacharias_FictionalCustomers.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
       
        [Display(Name ="Employee")]
        [Required(ErrorMessage ="Please Enter Your Name")]
        public string Name { get; set; }

        [Display(Name = "Email Adress")]
        [Required(ErrorMessage = "Please Enter Your Email Adress")]
        public string Email { get; set; }

        [Display(Name = "Adress")]
        [Required(ErrorMessage = "Please Enter Your Adress")]
        public string Adress { get; set; }
        
        [Display(Name = "Programming Language")]
        [Required(ErrorMessage = "Please Enter Your Specified Language")]
        public string ProgrammingLanguage { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter Your Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please Confirm Your Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        //[DisplayName("Assigned Project")]
        //public int ProjectId { get; set; }


        //public AssignedProject AssignedProject { get; set; }

    }
}
