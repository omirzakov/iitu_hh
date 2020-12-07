using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iitu_project_hh.Controllers
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeOwnerId { get; set; }
        public string EmployeePosition { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeTimeWork { get; set; }
        public string EmployeePhoto { get; set; }
        public int EmployeeSalary { get; set; }


        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}