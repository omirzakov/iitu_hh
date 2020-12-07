using iitu_project_hh.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iitu_project_hh.Models
{
    public class ProjectTasks
    {
        public int TaskId { get; set; }

        public string OwnerId { get; set; }
        public String Text { get; set; }
        public DateTime DeadLine { get; set; }

        public bool Done { get; set; }

        public int? ProjectId { get; set; }

        public Project Project { get; set; }

    }
}