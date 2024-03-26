namespace FoodHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Cid = c.Int(nullable: false, identity: true),
                        CName = c.String(nullable: false),
                        phone = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Cid);
            
            CreateTable(
                "dbo.FoodOrders",
                c => new
                    {
                        Oid = c.Int(nullable: false, identity: true),
                        Cid = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        totalPrice = c.Single(nullable: false),
                        orderType = c.String(),
                        paymentStatus = c.String(),
                        orderStatus = c.String(),
                        Token = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Oid)
                .ForeignKey("dbo.Customers", t => t.Cid, cascadeDelete: true)
                .Index(t => t.Cid);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Fid = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false),
                        price = c.Single(nullable: false),
                        image = c.String(),
                        veg = c.String(nullable: false),
                        foodCount = c.Int(nullable: false),
                        Rid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Fid)
                .ForeignKey("dbo.Restaurants", t => t.Rid, cascadeDelete: true)
                .Index(t => t.Rid);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Rid = c.Int(nullable: false, identity: true),
                        RName = c.String(nullable: false),
                        RDescription = c.String(),
                        logo = c.String(),
                        username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.Rid);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        itemId = c.Int(nullable: false, identity: true),
                        Oid = c.Int(nullable: false),
                        Fid = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.itemId)
                .ForeignKey("dbo.Foods", t => t.Fid, cascadeDelete: true)
                .ForeignKey("dbo.FoodOrders", t => t.Oid, cascadeDelete: true)
                .Index(t => t.Oid)
                .Index(t => t.Fid);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OrderItems", "Oid", "dbo.FoodOrders");
            DropForeignKey("dbo.OrderItems", "Fid", "dbo.Foods");
            DropForeignKey("dbo.Foods", "Rid", "dbo.Restaurants");
            DropForeignKey("dbo.FoodOrders", "Cid", "dbo.Customers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OrderItems", new[] { "Fid" });
            DropIndex("dbo.OrderItems", new[] { "Oid" });
            DropIndex("dbo.Foods", new[] { "Rid" });
            DropIndex("dbo.FoodOrders", new[] { "Cid" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Foods");
            DropTable("dbo.FoodOrders");
            DropTable("dbo.Customers");
        }
    }
}
