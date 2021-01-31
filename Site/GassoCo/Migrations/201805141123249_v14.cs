namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sliders", "Summary", c => c.String(maxLength: 200));
            AddColumn("dbo.Sliders", "SummaryEn", c => c.String(maxLength: 200));
            AddColumn("dbo.Sliders", "LinkTitle", c => c.String(maxLength: 200));
            AddColumn("dbo.Sliders", "LinkTitleEn", c => c.String(maxLength: 200));
            DropColumn("dbo.Sliders", "Summery");
            DropColumn("dbo.Sliders", "SummeryEn");
            DropColumn("dbo.Sliders", "LinkAddressEn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sliders", "LinkAddressEn", c => c.String(maxLength: 200));
            AddColumn("dbo.Sliders", "SummeryEn", c => c.String(maxLength: 200));
            AddColumn("dbo.Sliders", "Summery", c => c.String(maxLength: 200));
            DropColumn("dbo.Sliders", "LinkTitleEn");
            DropColumn("dbo.Sliders", "LinkTitle");
            DropColumn("dbo.Sliders", "SummaryEn");
            DropColumn("dbo.Sliders", "Summary");
        }
    }
}
