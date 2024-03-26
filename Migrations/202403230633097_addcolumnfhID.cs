namespace FoodHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumnfhID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodOrders", "Rid", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "fhID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "fhID");
            DropColumn("dbo.FoodOrders", "Rid");
        }
    }
}
