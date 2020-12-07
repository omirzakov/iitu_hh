using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iitu_project_hh.Controllers
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string ProjectOwnerId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }

        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}