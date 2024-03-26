namespace FoodHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datainsert : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Restaurants( RName, RDescription, logo, username, password)
VALUES('The Spice Route', 'Embark on a culinary journey with our diverse selection of aromatic spices and flavors from around the world.', 'x', 'spiceroute_admin', 'spice2022');

            INSERT INTO Restaurants(RName, RDescription, logo, username, password)
VALUES('Ocean Breeze Seafood Grill', 'Indulge in the freshest seafood dishes inspired by coastal cuisines from across the globe.', 'x', 'oceanbreeze_admin', 'seafood123');

            INSERT INTO Restaurants(RName, RDescription, logo, username, password)
VALUES('Green Garden Vegetarian Cuisine', 'Delight in wholesome and flavorful vegetarian fare crafted with fresh, locally sourced ingredients.', 'x', 'greengarden_admin', 'veggie456');

            INSERT INTO Restaurants(RName, RDescription, logo, username, password)
VALUES('Fire & Spice BBQ Pit', 'Experience the bold flavors and smoky goodness of authentic barbecue dishes slow-cooked to perfection.', 'x', 'fireandspice_admin', 'bbq789');

            INSERT INTO Restaurants(RName, RDescription, logo, username, password)
VALUES('Heavenly Desserts Cafe', 'Indulge your sweet tooth with our heavenly selection of decadent desserts and artisanal treats.', 'x', 'heavenlydesserts_admin', 'sweet2023');
");
            



        }

        public override void Down()
        {
        }
    }
}
