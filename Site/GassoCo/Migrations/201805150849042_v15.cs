namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Company = c.String(nullable: false, maxLength: 200),
                        CompanyEn = c.String(nullable: false, maxLength: 200),
                        Title = c.String(nullable: false),
                        TitleEn = c.String(nullable: false),
                        ImageUrl = c.String(maxLength: 200),
                        Subject = c.String(nullable: false),
                        SubjectEn = c.String(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        SubmitDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Certificates");
        }
    }
}
