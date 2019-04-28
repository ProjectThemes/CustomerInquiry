namespace CustomerInquiry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomizeDatasize2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transaction", "CurrencyCode", c => c.String(maxLength: 5));
            AlterColumn("dbo.Transaction", "Status", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transaction", "Status", c => c.String());
            AlterColumn("dbo.Transaction", "CurrencyCode", c => c.String());
        }
    }
}
