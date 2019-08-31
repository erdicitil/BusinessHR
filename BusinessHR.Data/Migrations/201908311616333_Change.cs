namespace BusinessHR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Employees", new[] { "CountryId" });
            DropIndex("dbo.Employees", new[] { "CityId" });
            DropIndex("dbo.Employees", new[] { "RegionId" });
            AlterColumn("dbo.Employees", "CountryId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Employees", "CityId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Employees", "RegionId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Employees", "CountryId");
            CreateIndex("dbo.Employees", "CityId");
            CreateIndex("dbo.Employees", "RegionId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "RegionId" });
            DropIndex("dbo.Employees", new[] { "CityId" });
            DropIndex("dbo.Employees", new[] { "CountryId" });
            AlterColumn("dbo.Employees", "RegionId", c => c.Guid());
            AlterColumn("dbo.Employees", "CityId", c => c.Guid());
            AlterColumn("dbo.Employees", "CountryId", c => c.Guid());
            CreateIndex("dbo.Employees", "RegionId");
            CreateIndex("dbo.Employees", "CityId");
            CreateIndex("dbo.Employees", "CountryId");
        }
    }
}
