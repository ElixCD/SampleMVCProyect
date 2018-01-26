namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TblEmployee", "FirstName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TblEmployee", "FirstName", c => c.String(nullable: false));
        }
    }
}
