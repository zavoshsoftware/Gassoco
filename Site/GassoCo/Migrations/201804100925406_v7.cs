namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        SubmitDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Place = c.String(),
                        Subject = c.String(),
                        ImageUrl = c.String(),
                        CustomerGroupId = c.Guid(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        SubmitDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerGroups", t => t.CustomerGroupId, cascadeDelete: true)
                .Index(t => t.CustomerGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "CustomerGroupId", "dbo.CustomerGroups");
            DropIndex("dbo.Customers", new[] { "CustomerGroupId" });
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerGroups");
        }
    }
}
