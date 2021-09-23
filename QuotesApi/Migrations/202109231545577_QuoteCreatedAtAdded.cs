namespace QuotesApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuoteCreatedAtAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quotes", "created_at", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quotes", "created_at");
        }
    }
}
