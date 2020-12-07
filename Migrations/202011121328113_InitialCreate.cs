namespace iitu_project_hh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        EmployeeEmail = c.String(),
                        EmployeeOwnerId = c.String(),
                        EmployeePosition = c.String(),
                        EmployeePhone = c.String(),
                        EmployeeTimeWork = c.String(),
                        EmployeePhoto = c.String(),
                        EmployeeSalary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EmployeeProjects",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.ProjectId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectOwnerId = c.String(),
                        ProjectName = c.String(),
                        ProjectDescription = c.String(),
                        Project_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId)
                .Index(t => t.Project_ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.EmployeeProjects", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.EmployeeProjects", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Projects", new[] { "Project_ProjectId" });
            DropIndex("dbo.EmployeeProjects", new[] { "ProjectId" });
            DropIndex("dbo.EmployeeProjects", new[] { "EmployeeId" });
            DropTable("dbo.Projects");
            DropTable("dbo.EmployeeProjects");
            DropTable("dbo.Employees");
        }
    }
}
