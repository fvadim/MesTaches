namespace MesTaches.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFinalDateTimeToTachesModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Taches", "FinalDT", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Taches", "FinalDT");
        }
    }
}
