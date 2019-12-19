namespace TaskManagementService.DAL.TaskManagementServiceContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblAllTasks",
                c => new
                    {
                        AllTaskId = c.Int(nullable: false, identity: true),
                        TaskCode = c.String(nullable: false, maxLength: 10),
                        TaskSubject = c.String(nullable: false, maxLength: 100),
                        TaskBody = c.String(maxLength: 300),
                        CreatedDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        isReplyed = c.Boolean(nullable: false),
                        isClosed = c.Boolean(nullable: false),
                        TaskTypeId = c.Int(nullable: false),
                        LevelId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        CreatedByEmployeeId = c.Int(nullable: false),
                        AssignedToEmployeeId = c.Int(nullable: true),
                        AssignedToDepartmentId = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.AllTaskId)
                .ForeignKey("dbo.tblEmployees", t => t.AssignedToEmployeeId)
                .ForeignKey("dbo.tblEmployees", t => t.CreatedByEmployeeId)
                .ForeignKey("dbo.tblDepartments", t => t.AssignedToDepartmentId)
                .ForeignKey("dbo.tblLevels", t => t.LevelId)
                .ForeignKey("dbo.tblPriorities", t => t.PriorityId)
                .ForeignKey("dbo.tblTaskTypes", t => t.TaskTypeId)
                .Index(t => t.TaskTypeId)
                .Index(t => t.LevelId)
                .Index(t => t.PriorityId)
                .Index(t => t.CreatedByEmployeeId)
                .Index(t => t.AssignedToEmployeeId)
                .Index(t => t.AssignedToDepartmentId);
            
            CreateTable(
                "dbo.tblEmployees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 50),
                        EmployeeCode = c.String(nullable: false, maxLength: 14),
                        EmployeeCnic = c.String(nullable: false, maxLength: 20),
                        EmployeeMobile1 = c.String(maxLength: 13),
                        EmployeeMobile2 = c.String(maxLength: 13),
                        EmployeeEmail1 = c.String(maxLength: 20),
                        EmployeeEmail2 = c.String(maxLength: 20),
                        EmployeeAddress1 = c.String(maxLength: 50),
                        EmployeeAddress2 = c.String(maxLength: 50),
                        BranchId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.tblBranches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.tblDepartments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.tblDesignations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.BranchId)
                .Index(t => t.DepartmentId)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.tblBranches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        BranchName = c.String(nullable: false, maxLength: 100),
                        BranchAddress = c.String(),
                        BranchEmail = c.String(),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BranchId)
                .ForeignKey("dbo.tblCompanies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.tblCompanies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyLogo = c.String(),
                        CompanyName = c.String(nullable: false, maxLength: 50),
                        CompanyAddress = c.String(maxLength: 300),
                        CompanyRegistrationNumber = c.String(maxLength: 300),
                        CompanyTaxNumber = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.tblDepartments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 300),
                        DepartmentCode = c.String(),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.tblCompanies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.tblDesignations",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(nullable: false, maxLength: 100),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DesignationId)
                .ForeignKey("dbo.tblCompanies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.tblTaskDetails",
                c => new
                    {
                        TaskDetailId = c.Int(nullable: false, identity: true),
                        Comment = c.String(nullable: false, maxLength: 300),
                        CommentDateTime = c.DateTime(nullable: false),
                        isReplyed = c.Boolean(nullable: false),
                        AllTaskId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskDetailId)
                .ForeignKey("dbo.tblAllTasks", t => t.AllTaskId)
                .ForeignKey("dbo.tblEmployees", t => t.EmployeeId)
                .Index(t => t.AllTaskId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.tblLevels",
                c => new
                    {
                        LevelId = c.Int(nullable: false, identity: true),
                        LevelName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.LevelId);
            
            CreateTable(
                "dbo.tblPriorities",
                c => new
                    {
                        PriorityId = c.Int(nullable: false),
                        PriorityName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.PriorityId);
            
            CreateTable(
                "dbo.tblTaskTypes",
                c => new
                    {
                        TaskTypeId = c.Int(nullable: false, identity: true),
                        TaskTypeName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.TaskTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblAllTasks", "TaskTypeId", "dbo.tblTaskTypes");
            DropForeignKey("dbo.tblAllTasks", "PriorityId", "dbo.tblPriorities");
            DropForeignKey("dbo.tblAllTasks", "LevelId", "dbo.tblLevels");
            DropForeignKey("dbo.tblAllTasks", "AssignedToDepartmentId", "dbo.tblDepartments");
            DropForeignKey("dbo.tblAllTasks", "CreatedByEmployeeId", "dbo.tblEmployees");
            DropForeignKey("dbo.tblAllTasks", "AssignedToEmployeeId", "dbo.tblEmployees");
            DropForeignKey("dbo.tblTaskDetails", "EmployeeId", "dbo.tblEmployees");
            DropForeignKey("dbo.tblTaskDetails", "AllTaskId", "dbo.tblAllTasks");
            DropForeignKey("dbo.tblEmployees", "DesignationId", "dbo.tblDesignations");
            DropForeignKey("dbo.tblEmployees", "DepartmentId", "dbo.tblDepartments");
            DropForeignKey("dbo.tblEmployees", "BranchId", "dbo.tblBranches");
            DropForeignKey("dbo.tblBranches", "CompanyId", "dbo.tblCompanies");
            DropForeignKey("dbo.tblDesignations", "CompanyId", "dbo.tblCompanies");
            DropForeignKey("dbo.tblDepartments", "CompanyId", "dbo.tblCompanies");
            DropIndex("dbo.tblTaskDetails", new[] { "EmployeeId" });
            DropIndex("dbo.tblTaskDetails", new[] { "AllTaskId" });
            DropIndex("dbo.tblDesignations", new[] { "CompanyId" });
            DropIndex("dbo.tblDepartments", new[] { "CompanyId" });
            DropIndex("dbo.tblBranches", new[] { "CompanyId" });
            DropIndex("dbo.tblEmployees", new[] { "DesignationId" });
            DropIndex("dbo.tblEmployees", new[] { "DepartmentId" });
            DropIndex("dbo.tblEmployees", new[] { "BranchId" });
            DropIndex("dbo.tblAllTasks", new[] { "AssignedToDepartmentId" });
            DropIndex("dbo.tblAllTasks", new[] { "AssignedToEmployeeId" });
            DropIndex("dbo.tblAllTasks", new[] { "CreatedByEmployeeId" });
            DropIndex("dbo.tblAllTasks", new[] { "PriorityId" });
            DropIndex("dbo.tblAllTasks", new[] { "LevelId" });
            DropIndex("dbo.tblAllTasks", new[] { "TaskTypeId" });
            DropTable("dbo.tblTaskTypes");
            DropTable("dbo.tblPriorities");
            DropTable("dbo.tblLevels");
            DropTable("dbo.tblTaskDetails");
            DropTable("dbo.tblDesignations");
            DropTable("dbo.tblDepartments");
            DropTable("dbo.tblCompanies");
            DropTable("dbo.tblBranches");
            DropTable("dbo.tblEmployees");
            DropTable("dbo.tblAllTasks");
        }
    }
}
