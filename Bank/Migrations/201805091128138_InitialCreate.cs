namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                        Holder_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Holder_Id)
                .Index(t => t.Holder_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FisrtName = c.String(),
                        MiddleName = c.String(),
                        SurName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "Holder_Id", "dbo.Users");
            DropIndex("dbo.Accounts", new[] { "Holder_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Accounts");
        }
    }
}
