namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v171 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductGroups", "Description", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductGroups", "Description", c => c.String(maxLength: 2000));
        }
    }
}
