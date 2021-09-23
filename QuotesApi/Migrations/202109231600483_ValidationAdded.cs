namespace QuotesApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Quotes", "title", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Quotes", "author", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Quotes", "description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Quotes", "type", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Quotes", "type", c => c.String());
            AlterColumn("dbo.Quotes", "description", c => c.String());
            AlterColumn("dbo.Quotes", "author", c => c.String());
            AlterColumn("dbo.Quotes", "title", c => c.String());
        }
    }
}
