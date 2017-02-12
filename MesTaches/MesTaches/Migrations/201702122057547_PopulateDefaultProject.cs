namespace MesTaches.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDefaultProject : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Projets ( Name) VALUES ( 'Default')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Progets WHERE Id = 1");
        }
    }
}
