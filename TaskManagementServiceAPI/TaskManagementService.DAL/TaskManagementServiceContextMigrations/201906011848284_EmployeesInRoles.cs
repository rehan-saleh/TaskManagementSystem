namespace TaskManagementService.DAL.TaskManagementServiceContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeesInRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblEmployeesInRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.EmployeeId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblEmployeesInRoles");
        }
    }
}
