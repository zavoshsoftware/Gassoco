namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactusForms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        fullname = c.String(nullable: false, maxLength: 100),
                        email = c.String(nullable: false, maxLength: 100),
                        message = c.String(nullable: false, maxLength: 100),
                        IsDelete = c.Boolean(nullable: false),
                        SubmitDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactusForms");
        }
    }
}
