namespace Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TextTypeItems", "Summary1", c => c.String(maxLength: 1000));
            AlterColumn("dbo.TextTypeItems", "Summary2", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TextTypeItems", "Summary2", c => c.String(maxLength: 200));
            AlterColumn("dbo.TextTypeItems", "Summary1", c => c.String(maxLength: 200));
        }
    }
}
