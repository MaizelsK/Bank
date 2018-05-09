namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FirstName", c => c.String());
            DropColumn("dbo.Users", "FisrtName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "FisrtName", c => c.String());
            DropColumn("dbo.Users", "FirstName");
        }
    }
}
