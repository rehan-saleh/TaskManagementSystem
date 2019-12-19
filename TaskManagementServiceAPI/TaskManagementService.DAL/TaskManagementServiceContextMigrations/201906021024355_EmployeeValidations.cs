namespace TaskManagementService.DAL.TaskManagementServiceContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblEmployees", "EmployeeName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.tblEmployees", "EmployeeCnic", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.tblEmployees", "EmployeeMobile1", c => c.String(maxLength: 100));
            AlterColumn("dbo.tblEmployees", "EmployeeMobile2", c => c.String(maxLength: 100));
            AlterColumn("dbo.tblEmployees", "EmployeeEmail1", c => c.String(maxLength: 100));
            AlterColumn("dbo.tblEmployees", "EmployeeEmail2", c => c.String(maxLength: 100));
            AlterColumn("dbo.tblEmployees", "EmployeeAddress1", c => c.String(maxLength: 1000));
            AlterColumn("dbo.tblEmployees", "EmployeeAddress2", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblEmployees", "EmployeeAddress2", c => c.String(maxLength: 50));
            AlterColumn("dbo.tblEmployees", "EmployeeAddress1", c => c.String(maxLength: 50));
            AlterColumn("dbo.tblEmployees", "EmployeeEmail2", c => c.String(maxLength: 20));
            AlterColumn("dbo.tblEmployees", "EmployeeEmail1", c => c.String(maxLength: 20));
            AlterColumn("dbo.tblEmployees", "EmployeeMobile2", c => c.String(maxLength: 13));
            AlterColumn("dbo.tblEmployees", "EmployeeMobile1", c => c.String(maxLength: 13));
            AlterColumn("dbo.tblEmployees", "EmployeeCnic", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.tblEmployees", "EmployeeName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
