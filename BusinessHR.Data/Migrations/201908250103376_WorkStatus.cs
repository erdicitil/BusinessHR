namespace BusinessHR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkStatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "WorkStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "WorkStatus", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
