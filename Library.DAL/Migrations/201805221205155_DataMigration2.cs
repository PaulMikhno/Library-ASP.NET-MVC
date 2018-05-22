namespace Library.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Brochures", "TypeOfCover", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Brochures", "TypeOfCover", c => c.String());
        }
    }
}
