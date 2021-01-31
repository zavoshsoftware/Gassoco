namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        Summery = c.String(maxLength: 500),
                        Detail = c.String(storeType: "ntext"),
                        ImageUrl = c.String(maxLength: 200),
                        VisitNumber = c.Int(nullable: false),
                        TitleEn = c.String(nullable: false, maxLength: 200),
                        SummeryEn = c.String(maxLength: 500),
                        DetailEn = c.String(storeType: "ntext"),
                        IsDelete = c.Boolean(nullable: false),
                        SubmitDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 200),
                        ImageUrl = c.String(maxLength: 200),
                        TitleEn = c.String(maxLength: 200),
                        IsDelete = c.Boolean(nullable: false),
                        SubmitDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GalleryImages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 200),
                        TitleEn = c.String(maxLength: 200),
                        ImageUrl = c.String(maxLength: 200),
                        GalleryId = c.Guid(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        SubmitDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: true)
                .Index(t => t.GalleryId);
            
            CreateTable(
                "dbo.ProducImages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ImageUrl = c.String(maxLength: 200),
                        ProductId = c.Guid(nullable: false),
                        ProductImageTypeId = c.Guid(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        SubmitDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ProductImageTypes", t => t.ProductImageTypeId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ProductImageTypeId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductGroupId = c.Guid(nullable: false),
                        Title = c.String(maxLength: 200),
                        Summary = c.String(maxLength: 500),
                        Body = c.String(storeType: "ntext"),
                        ImageUrl = c.String(maxLength: 200),
                        FlashImageUrl = c.String(maxLength: 200),
                        TitleEn = c.String(maxLength: 200),
                        SummaryEn = c.String(maxLength: 500),
                        BodyEn = c.String(storeType: "ntext"),
                        IsDelete = c.Boolean(nullable: false),
                        SubmitDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductGroups", t => t.ProductGroupId, cascadeDelete: true)
                .Index(t => t.ProductGroupId);
            
            CreateTable(
                "dbo.ProductGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 200),
                        TitleEn = c.String(maxLength: 200),
                        Description = c.String(maxLength: 2000),
                        DescriptionEn = c.String(maxLength: 2000),
                        ParentId = c.Guid(),
                        Priority = c.Int(nullable: false),
                        ImageUrl = c.String(maxLength: 200),
                        IsDelete = c.Boolean(nullable: false),
                        SubmitDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                        ParentProductGroup_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductGroups", t => t.ParentProductGroup_Id)
                .Index(t => t.ParentProductGroup_Id);
            
            CreateTable(
                "dbo.ProductImageTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 200),
                        IsDelete = c.Boolean(nullable: false),
                        SubmitDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResumeForms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        NationalCode = c.String(maxLength: 10),
                        Phone = c.String(maxLength: 20),
                        Mobile = c.String(maxLength: 15),
                        Email = c.String(maxLength: 260),
                        ResumeFile = c.String(maxLength: 200),
                        IsDelete = c.Boolean(nullable: false),
                        SubmitDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 200),
                        Summery = c.String(maxLength: 200),
                        LinkAddress = c.String(maxLength: 200),
                        ImageUrl = c.String(maxLength: 200),
                        Priority = c.Int(nullable: false),
                        TitleEn = c.String(maxLength: 200),
                        SummeryEn = c.String(maxLength: 200),
                        LinkAddressEn = c.String(maxLength: 200),
                        IsDelete = c.Boolean(nullable: false),
                        SubmitDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TextTypeItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 200),
                        Summary1 = c.String(maxLength: 200),
                        Summary2 = c.String(maxLength: 200),
                        Body = c.String(storeType: "ntext"),
                        ImageUrl = c.String(maxLength: 200),
                        TextTypeId = c.Guid(nullable: false),
                        TitleEn = c.String(maxLength: 200),
                        Summary1En = c.String(maxLength: 200),
                        Summary2En = c.String(maxLength: 200),
                        BodyEn = c.String(storeType: "ntext"),
                        IsDelete = c.Boolean(nullable: false),
                        SubmitDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TextTypes", t => t.TextTypeId, cascadeDelete: true)
                .Index(t => t.TextTypeId);
            
            CreateTable(
                "dbo.TextTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 200),
                        IsDelete = c.Boolean(nullable: false),
                        SubmitDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TextTypeItems", "TextTypeId", "dbo.TextTypes");
            DropForeignKey("dbo.ProducImages", "ProductImageTypeId", "dbo.ProductImageTypes");
            DropForeignKey("dbo.ProducImages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductGroupId", "dbo.ProductGroups");
            DropForeignKey("dbo.ProductGroups", "ParentProductGroup_Id", "dbo.ProductGroups");
            DropForeignKey("dbo.GalleryImages", "GalleryId", "dbo.Galleries");
            DropIndex("dbo.TextTypeItems", new[] { "TextTypeId" });
            DropIndex("dbo.ProductGroups", new[] { "ParentProductGroup_Id" });
            DropIndex("dbo.Products", new[] { "ProductGroupId" });
            DropIndex("dbo.ProducImages", new[] { "ProductImageTypeId" });
            DropIndex("dbo.ProducImages", new[] { "ProductId" });
            DropIndex("dbo.GalleryImages", new[] { "GalleryId" });
            DropTable("dbo.TextTypes");
            DropTable("dbo.TextTypeItems");
            DropTable("dbo.Sliders");
            DropTable("dbo.ResumeForms");
            DropTable("dbo.ProductImageTypes");
            DropTable("dbo.ProductGroups");
            DropTable("dbo.Products");
            DropTable("dbo.ProducImages");
            DropTable("dbo.GalleryImages");
            DropTable("dbo.Galleries");
            DropTable("dbo.Blogs");
        }
    }
}
