namespace FoodHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customertablemodify : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Restaurants", "username");
            DropColumn("dbo.Restaurants", "password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "password", c => c.String());
            AddColumn("dbo.Restaurants", "username", c => c.String());
        }
    }
}
