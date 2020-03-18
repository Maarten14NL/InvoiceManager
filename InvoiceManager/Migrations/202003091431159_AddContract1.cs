namespace InvoiceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContract1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "Hide", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contracts", "Hide");
        }
    }
}
