namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catalogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        File = c.String(maxLength: 200),
                        Description = c.String(storeType: "ntext"),
                        IsEn = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        SubmitDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Catalogs");
        }
    }
}
