namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.Careers", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.Catalogs", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.Certificates", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.ContactusForms", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.CustomerGroups", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.Customers", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.Galleries", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.GalleryImages", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.NewsLetters", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.ProducImages", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.Products", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.ProductGroups", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.ProductImageTypes", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.ResumeForms", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.Roles", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.Users", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.ServiceItems", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.Services", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.Sliders", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.TextTypeItems", "LastModificationDate", c => c.DateTime());
            AddColumn("dbo.TextTypes", "LastModificationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TextTypes", "LastModificationDate");
            DropColumn("dbo.TextTypeItems", "LastModificationDate");
            DropColumn("dbo.Sliders", "LastModificationDate");
            DropColumn("dbo.Services", "LastModificationDate");
            DropColumn("dbo.ServiceItems", "LastModificationDate");
            DropColumn("dbo.Users", "LastModificationDate");
            DropColumn("dbo.Roles", "LastModificationDate");
            DropColumn("dbo.ResumeForms", "LastModificationDate");
            DropColumn("dbo.ProductImageTypes", "LastModificationDate");
            DropColumn("dbo.ProductGroups", "LastModificationDate");
            DropColumn("dbo.Products", "LastModificationDate");
            DropColumn("dbo.ProducImages", "LastModificationDate");
            DropColumn("dbo.NewsLetters", "LastModificationDate");
            DropColumn("dbo.GalleryImages", "LastModificationDate");
            DropColumn("dbo.Galleries", "LastModificationDate");
            DropColumn("dbo.Customers", "LastModificationDate");
            DropColumn("dbo.CustomerGroups", "LastModificationDate");
            DropColumn("dbo.ContactusForms", "LastModificationDate");
            DropColumn("dbo.Certificates", "LastModificationDate");
            DropColumn("dbo.Catalogs", "LastModificationDate");
            DropColumn("dbo.Careers", "LastModificationDate");
            DropColumn("dbo.Blogs", "LastModificationDate");
        }
    }
}
