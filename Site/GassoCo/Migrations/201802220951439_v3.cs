namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ServiceItems", "Title", c => c.String(nullable: false, storeType: "ntext"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceItems", "Title", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
