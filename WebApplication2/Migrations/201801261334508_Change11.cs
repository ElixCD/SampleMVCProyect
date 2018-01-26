namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TblEmployee", "Salary", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TblEmployee", "Salary", c => c.Int(nullable: false));
        }
    }
}
