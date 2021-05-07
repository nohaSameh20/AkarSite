namespace AkaraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig03 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertising",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                        Area = c.Int(nullable: false),
                        Image = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        BuildingStatus = c.Int(nullable: false),
                        AdvertisingStatuse = c.Int(nullable: false),
                        UnitType = c.Int(nullable: false),
                        NoRoom = c.Int(nullable: false),
                        Location = c.String(),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Advertising", "UserId", "dbo.User");
            DropIndex("dbo.Advertising", new[] { "UserId" });
            DropTable("dbo.Advertising");
        }
    }
}
