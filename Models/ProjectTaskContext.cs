using iitu_project_hh.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace iitu_project_hh.Models
{
    public class ProjectTaskContext : DbContext
    {
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectTasks> ProjectTasks { get; set; }
    }
}