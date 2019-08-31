namespace BusinessHR.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Photo = c.String(maxLength: 200),
                        Gender = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        IdentityNumber = c.Int(nullable: false),
                        Mobile = c.String(nullable: false, maxLength: 20),
                        Nationality = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 100),
                        DepartmentId = c.Guid(nullable: false),
                        PositionId = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 4000),
                        CompanyWorkStartDate = c.DateTime(nullable: false),
                        CompanyWorkEndDate = c.DateTime(),
                        SalaryId = c.Guid(nullable: false),
                        CertificateId = c.Guid(),
                        CountryId = c.Guid(),
                        CityId = c.Guid(),
                        RegionId = c.Guid(),
                        WorkStatus = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                        Permission_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Certificates", t => t.CertificateId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Positions", t => t.PositionId)
                .ForeignKey("dbo.Regions", t => t.RegionId)
                .ForeignKey("dbo.Salaries", t => t.SalaryId)
                .ForeignKey("dbo.Permissions", t => t.Permission_Id)
                .Index(t => t.DepartmentId)
                .Index(t => t.PositionId)
                .Index(t => t.SalaryId)
                .Index(t => t.CertificateId)
                .Index(t => t.CountryId)
                .Index(t => t.CityId)
                .Index(t => t.RegionId)
                .Index(t => t.Permission_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        CountryId = c.Guid(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(maxLength: 20),
                        Address = c.String(maxLength: 500),
                        CountryId = c.Guid(nullable: false),
                        CityId = c.Guid(nullable: false),
                        RegionId = c.Guid(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.Regions", t => t.RegionId)
                .Index(t => t.CountryId)
                .Index(t => t.CityId)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        CompanyId = c.Guid(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        DepartmentId = c.Guid(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        CityId = c.Guid(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Maas = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BrutMaas = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetMaas = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AGI = c.Decimal(nullable: false, precision: 18, scale: 2),
                        KGV = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Odenen = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Durum = c.String(nullable: false, maxLength: 100),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PermissionStartDate = c.DateTime(nullable: false),
                        PermissionEndDate = c.DateTime(nullable: false),
                        PermissionTime = c.String(nullable: false, maxLength: 100),
                        PermissionTypeId = c.Guid(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PermissionTypes", t => t.PermissionTypeId)
                .Index(t => t.PermissionTypeId);
            
            CreateTable(
                "dbo.PermissionTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Permissions", "PermissionTypeId", "dbo.PermissionTypes");
            DropForeignKey("dbo.Employees", "Permission_Id", "dbo.Permissions");
            DropForeignKey("dbo.Employees", "SalaryId", "dbo.Salaries");
            DropForeignKey("dbo.Employees", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Employees", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Employees", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Employees", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Companies", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Regions", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Positions", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Companies", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Companies", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Employees", "CertificateId", "dbo.Certificates");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Permissions", new[] { "PermissionTypeId" });
            DropIndex("dbo.Regions", new[] { "CityId" });
            DropIndex("dbo.Positions", new[] { "DepartmentId" });
            DropIndex("dbo.Departments", new[] { "CompanyId" });
            DropIndex("dbo.Companies", new[] { "RegionId" });
            DropIndex("dbo.Companies", new[] { "CityId" });
            DropIndex("dbo.Companies", new[] { "CountryId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Employees", new[] { "Permission_Id" });
            DropIndex("dbo.Employees", new[] { "RegionId" });
            DropIndex("dbo.Employees", new[] { "CityId" });
            DropIndex("dbo.Employees", new[] { "CountryId" });
            DropIndex("dbo.Employees", new[] { "CertificateId" });
            DropIndex("dbo.Employees", new[] { "SalaryId" });
            DropIndex("dbo.Employees", new[] { "PositionId" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PermissionTypes");
            DropTable("dbo.Permissions");
            DropTable("dbo.Salaries");
            DropTable("dbo.Regions");
            DropTable("dbo.Positions");
            DropTable("dbo.Departments");
            DropTable("dbo.Countries");
            DropTable("dbo.Companies");
            DropTable("dbo.Cities");
            DropTable("dbo.Employees");
            DropTable("dbo.Certificates");
        }
    }
}
