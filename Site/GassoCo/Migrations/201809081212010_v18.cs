namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "MetaDescription", c => c.String(maxLength: 320));
            AddColumn("dbo.Blogs", "MetaDescriptionEn", c => c.String(maxLength: 320));
            AddColumn("dbo.Products", "MetaDescription", c => c.String(maxLength: 320));
            AddColumn("dbo.Products", "MetaDescriptionEn", c => c.String(maxLength: 320));
            AddColumn("dbo.ProductGroups", "MetaDescription", c => c.String(maxLength: 320));
            AddColumn("dbo.ProductGroups", "MetaDescriptionEn", c => c.String(maxLength: 320));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductGroups", "MetaDescriptionEn");
            DropColumn("dbo.ProductGroups", "MetaDescription");
            DropColumn("dbo.Products", "MetaDescriptionEn");
            DropColumn("dbo.Products", "MetaDescription");
            DropColumn("dbo.Blogs", "MetaDescriptionEn");
            DropColumn("dbo.Blogs", "MetaDescription");
        }
    }
}
