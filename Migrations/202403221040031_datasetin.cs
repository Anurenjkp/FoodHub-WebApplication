namespace FoodHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datasetin : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Pepper Chicken', 480.0, 'x', 'No', 50, 1);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Garlic Chicken', 400.0, 'x', 'No', 60, 1);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Rotti', 80.0, 'x', 'Yes', 80, 1);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Chicken Roast', 520.0, 'x', 'No', 40, 1);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Veg Kurma', 350.0, 'x', 'Yes', 70, 1);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Gobi Manchurian', 300.0, 'x', 'Yes', 90, 1);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Spicy Chicken Curry', 480.0, 'x', 'No', 50, 1);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Vegetable Biryani', 380.0, 'x', 'Yes', 60, 1);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Garlic Naan', 50.0, 'x', 'Yes', 45, 1);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Mango Lassi', 120.0, 'x', 'Yes', 50, 1);




INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Grilled Sea Bass', 700.0, 'x', 'No', 50, 2);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Shrimp Scampi', 600.0, 'x', 'No', 60, 2);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Lobster Bisque', 450.0, 'x', 'No', 40, 2);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Fish Tacos', 550.0, 'x', 'No', 70, 2);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Crab Cakes', 650.0, 'x', 'No', 80, 2);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Cajun Shrimp Pasta', 620.0, 'x', 'No', 55, 2);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Seafood Paella', 750.0, 'x', 'No', 65, 2);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Grilled Octopus', 680.0, 'x', 'No', 45, 2);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Stuffed Clams', 500.0, 'x', 'No', 75, 2);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Oyster Rockefeller', 600.0, 'x', 'No', 85, 2);



INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Vegetable Stir-Fry', 280.0, 'x', 'Yes', 50, 3);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Paneer Tikka', 320.0, 'x', 'Yes', 60, 3);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Spinach and Mushroom Quesadilla', 350.0, 'x', 'Yes', 40, 3);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Veggie Burger', 380.0, 'x', 'Yes', 70, 3);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Eggplant Parmesan', 400.0, 'x', 'Yes', 80, 3);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Quinoa Salad', 320.0, 'x', 'Yes', 55, 3);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Vegetable Curry', 350.0, 'x', 'Yes', 65, 3);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Stuffed Bell Peppers', 380.0, 'x', 'Yes', 45, 3);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Caprese Sandwich', 320.0, 'x', 'Yes', 75, 3);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Mushroom Risotto', 400.0, 'x', 'Yes', 85, 3);



INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('BBQ Ribs', 650.0, 'x', 'No', 50, 4);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Pulled Pork Sandwich', 580.0, 'x', 'No', 60, 4);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Brisket Platter', 700.0, 'x', 'No', 40, 4);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Smoked Chicken Wings', 550.0, 'x', 'No', 70, 4);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Cornbread Muffins', 250.0, 'x', 'Yes', 80, 4);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Mac and Cheese', 320.0, 'x', 'Yes', 55, 4);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Collard Greens', 280.0, 'x', 'Yes', 65, 4);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Sweet Potato Casserole', 350.0, 'x', 'Yes', 45, 4);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Pecan Pie', 400.0, 'x', 'Yes', 75, 4);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Banana Pudding', 280.0, 'x', 'Yes', 85, 4);




INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Chocolate Cake', 450.0, 'x', 'Yes', 50, 5);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Cheesecake', 400.0, 'x', 'Yes', 60, 5);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Apple Pie', 350.0, 'x', 'Yes', 40, 5);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Cupcakes', 300.0, 'x', 'Yes', 70, 5);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Brownies', 280.0, 'x', 'Yes', 80, 5);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Cookies', 250.0, 'x', 'Yes', 55, 5);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Fruit Tart', 320.0, 'x', 'Yes', 65, 5);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Tiramisu', 400.0, 'x', 'Yes', 45, 5);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Ice Cream Sundae', 350.0, 'x', 'Yes', 75, 5);
 
INSERT INTO Foods (FName, price, image, veg, foodCount, Rid)
VALUES ('Pavlova', 380.0, 'x', 'Yes', 85, 5);

");



        }
        
        public override void Down()
        {
        }
    }
}
