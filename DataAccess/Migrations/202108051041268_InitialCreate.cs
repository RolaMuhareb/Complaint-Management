namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComplaintDepartments",
                c => new
                    {
                        ComplaintDepartmentsId = c.Int(nullable: false, identity: true),
                        ComplaintRequestId = c.Int(),
                        DepartmentId = c.Int(),
                        CreatedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedById = c.Int(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ComplaintDepartmentsId)
                .ForeignKey("dbo.ComplaintRequests", t => t.ComplaintRequestId)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .Index(t => t.ComplaintRequestId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById);
            
            CreateTable(
                "dbo.ComplaintRequests",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        StatusId = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        ToHr = c.Boolean(nullable: false),
                        ToManager = c.Boolean(nullable: false),
                        ToTeamLeader = c.Boolean(nullable: false),
                        CreatedById = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedById = c.Int(),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        User_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.User_id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.User_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Number = c.String(),
                        Password = c.String(),
                        UserRoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.UserRoles", t => t.UserRoleID, cascadeDelete: true)
                .Index(t => t.UserRoleID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComplaintDepartments", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.ComplaintDepartments", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.ComplaintDepartments", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.ComplaintRequests", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.ComplaintDepartments", "ComplaintRequestId", "dbo.ComplaintRequests");
            DropForeignKey("dbo.ComplaintRequests", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Users", "UserRoleID", "dbo.UserRoles");
            DropForeignKey("dbo.ComplaintRequests", "User_id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "UserRoleID" });
            DropIndex("dbo.ComplaintRequests", new[] { "User_id" });
            DropIndex("dbo.ComplaintRequests", new[] { "ModifiedById" });
            DropIndex("dbo.ComplaintRequests", new[] { "CreatedById" });
            DropIndex("dbo.ComplaintDepartments", new[] { "ModifiedById" });
            DropIndex("dbo.ComplaintDepartments", new[] { "CreatedById" });
            DropIndex("dbo.ComplaintDepartments", new[] { "DepartmentId" });
            DropIndex("dbo.ComplaintDepartments", new[] { "ComplaintRequestId" });
            DropTable("dbo.Departments");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.ComplaintRequests");
            DropTable("dbo.ComplaintDepartments");
        }
    }
}
