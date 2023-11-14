namespace ShoeApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagecange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblProducts", "Prod_Image_Path", c => c.String());
            DropColumn("dbo.tblProducts", "Prod_Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblProducts", "Prod_Image", c => c.String());
            DropColumn("dbo.tblProducts", "Prod_Image_Path");
        }
    }
}
