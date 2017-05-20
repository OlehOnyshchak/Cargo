namespace Cargo.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Title", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "Title");
        }
    }
}
