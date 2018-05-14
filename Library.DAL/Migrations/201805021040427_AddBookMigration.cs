namespace Library.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Author = c.String(),
                        YearOfPublishing = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PublicHouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Brochures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TypeOfCover = c.String(),
                        NumberOfPages = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Magazines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.String(),
                        YearOfPublishing = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PublicHouseBooks",
                c => new
                    {
                        PublicHouse_Id = c.Int(nullable: false),
                        Book_Id = c.Int(name: "Book_Id ", nullable: false),
                    })
                .PrimaryKey(t => new { t.PublicHouse_Id, t.Book_Id })
                .ForeignKey("dbo.Books", t => t.PublicHouse_Id, cascadeDelete: true)
                .ForeignKey("dbo.PublicHouses", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.PublicHouse_Id)
                .Index(t => t.Book_Id, name: "IX_Book_Id");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PublicHouseBooks", "Book_Id ", "dbo.PublicHouses");
            DropForeignKey("dbo.PublicHouseBooks", "PublicHouse_Id", "dbo.Books");
            DropIndex("dbo.PublicHouseBooks", "IX_Book_Id");
            DropIndex("dbo.PublicHouseBooks", new[] { "PublicHouse_Id" });
            DropTable("dbo.PublicHouseBooks");
            DropTable("dbo.Magazines");
            DropTable("dbo.Brochures");
            DropTable("dbo.PublicHouses");
            DropTable("dbo.Books");
        }
    }
}
