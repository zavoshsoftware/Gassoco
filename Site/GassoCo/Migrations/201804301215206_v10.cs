namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceItems", "TitleEn", c => c.String(nullable: false, storeType: "ntext"));
            AddColumn("dbo.Services", "TitleEn", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "TitleEn");
            DropColumn("dbo.ServiceItems", "TitleEn");
        }
    }
}
