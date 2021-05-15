namespace AkaraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig01 : DbMigration
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
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Subject = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        AdvertisingId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advertising", t => t.AdvertisingId)
                .Index(t => t.AdvertisingId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        PhoneNumber = c.String(),
                        Image = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Advertising", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Comment", "AdvertisingId", "dbo.Advertising");
            DropIndex("dbo.User", new[] { "RoleId" });
            DropIndex("dbo.Comment", new[] { "AdvertisingId" });
            DropIndex("dbo.Advertising", new[] { "UserId" });
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.Comment");
            DropTable("dbo.Advertising");
        }
    }
}
