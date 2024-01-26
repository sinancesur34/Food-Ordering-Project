namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Satis", "Toplam", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Satis", "Toplam");
        }
    }
}
