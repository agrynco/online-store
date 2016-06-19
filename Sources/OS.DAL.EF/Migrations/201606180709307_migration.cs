namespace OS.DAL.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductPhotos", "WaterMarked_Id", c => c.Int());
            CreateIndex("dbo.ProductPhotos", "WaterMarked_Id");
            AddForeignKey("dbo.ProductPhotos", "WaterMarked_Id", "dbo.Files", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductPhotos", "WaterMarked_Id", "dbo.Files");
            DropIndex("dbo.ProductPhotos", new[] { "WaterMarked_Id" });
            DropColumn("dbo.ProductPhotos", "WaterMarked_Id");
        }
    }
}
