namespace FoodHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Photosinsert : DbMigration
    {
        public override void Up()
        {
            Sql(@"UPDATE Foods
SET [image] =
    CASE
        WHEN Rid = 1 AND Fid = 1 THEN 'F1R1'
        WHEN Rid = 1 AND Fid = 2 THEN 'F2R1'
        WHEN Rid = 1 AND Fid = 3 THEN 'F3R1'
        WHEN Rid = 1 AND Fid = 4 THEN 'F4R1'
        WHEN Rid = 1 AND Fid = 5 THEN 'F5R1'
        WHEN Rid = 1 AND Fid = 6 THEN 'F6R1'
        WHEN Rid = 1 AND Fid = 7 THEN 'F7R1'
        WHEN Rid = 1 AND Fid = 8 THEN 'F8R1'
        WHEN Rid = 1 AND Fid = 9 THEN 'F9R1'
        WHEN Rid = 1 AND Fid = 10 THEN 'F10R1'
        WHEN Rid = 2 AND Fid = 1 THEN 'F1R2'
        WHEN Rid = 2 AND Fid = 2 THEN 'F2R2'
        WHEN Rid = 2 AND Fid = 3 THEN 'F3R2'
        WHEN Rid = 2 AND Fid = 4 THEN 'F4R2'
        WHEN Rid = 2 AND Fid = 5 THEN 'F5R2'
        WHEN Rid = 2 AND Fid = 6 THEN 'F6R2'
        WHEN Rid = 2 AND Fid = 7 THEN 'F7R2'
        WHEN Rid = 2 AND Fid = 8 THEN 'F8R2'
        WHEN Rid = 2 AND Fid = 9 THEN 'F9R2'
        WHEN Rid = 2 AND Fid = 10 THEN 'F10R2'
        
    END; ");
        }
        
        public override void Down()
        {
        }
    }
}
