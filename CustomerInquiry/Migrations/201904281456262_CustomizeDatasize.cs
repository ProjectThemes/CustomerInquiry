namespace CustomerInquiry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomizeDatasize : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "CustomerName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Customer", "ContactEmail", c => c.String(maxLength: 25));
            AlterColumn("dbo.Customer", "MobileNo", c => c.String(maxLength: 10));
            AlterColumn("dbo.Transaction", "Amount", c => c.Decimal(nullable: false, precision: 12, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transaction", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Customer", "MobileNo", c => c.String());
            AlterColumn("dbo.Customer", "ContactEmail", c => c.String());
            AlterColumn("dbo.Customer", "CustomerName", c => c.String());
        }
    }
}
