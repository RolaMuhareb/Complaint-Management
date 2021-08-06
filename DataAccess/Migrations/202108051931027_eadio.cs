namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eadio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComplaintRequests", "TimeOfComplaint", c => c.DateTime(nullable: false));
            AddColumn("dbo.ComplaintRequests", "InCompany", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ComplaintRequests", "InCompany");
            DropColumn("dbo.ComplaintRequests", "TimeOfComplaint");
        }
    }
}
