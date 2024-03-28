namespace FoodHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addcolumntofoodorder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FoodOrders", "Rid", "dbo.Restaurants");
            DropIndex("dbo.FoodOrders", new[] { "Rid" });

        }
        
        public override void Down()
        {
            CreateIndex("dbo.FoodOrders", "Rid");
            AddForeignKey("dbo.FoodOrders", "Rid", "dbo.Restaurants", "Rid", cascadeDelete: true);
        }
    }
}
