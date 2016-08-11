namespace OS.DAL.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductCategoryArticle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategories", "Article", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductCategories", "Article");
        }
    }
}
