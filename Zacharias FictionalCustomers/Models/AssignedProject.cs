using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Zacharias_FictionalCustomers.Models
{
    public partial class AssignedProject
    {
        [Key]
        public int ProjectId { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Company Address")]
        public string Companyaddress { get; set; }

        [Display(Name = "Employee Task")]
        public string Task { get; set; }

        [Display(Name = "Project Added")]
        public DateTime Date { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        //public virtual ICollection<Employee> Projectstaff { get; set; }

    }
}
