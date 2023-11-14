namespace ShoeApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedimagecange : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblProducts", "Prod_Image_Path");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblProducts", "Prod_Image_Path", c => c.String());
        }
    }
}
