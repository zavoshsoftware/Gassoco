namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Order", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "Order");
        }
    }
}
