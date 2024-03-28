namespace FoodHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseAlter : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.FoodOrders", "Rid");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FoodOrders", new[] { "Rid" });
        }
    }
}
