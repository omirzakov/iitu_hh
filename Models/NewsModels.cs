using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace iitu_project_hh.Models
{
    public class NewsModels
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Text { get; set; }
        public DateTime AddedTime { get; set; }

        public String NewsImage { get; set; }

        public String OwnerId { get; set; }
    }

    public class NewsContext : DbContext
    {
        public DbSet<NewsModels> NewsModel { get; set; }
    }
}