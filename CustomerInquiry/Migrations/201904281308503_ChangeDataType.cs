namespace CustomerInquiry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transaction", "CurrencyCode", c => c.String());
            AlterColumn("dbo.Transaction", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transaction", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Transaction", "CurrencyCode", c => c.Int(nullable: false));
        }
    }
}
