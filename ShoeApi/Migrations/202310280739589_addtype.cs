namespace ShoeApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblUsers", "UserType", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblUsers", "UserType");
        }
    }
}
