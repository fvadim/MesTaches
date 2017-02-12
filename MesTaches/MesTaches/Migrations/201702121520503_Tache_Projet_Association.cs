namespace MesTaches.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tache_Projet_Association : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Associations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Projet_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projets", t => t.Projet_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Projet_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Projets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Taches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        CreateDT = c.DateTime(nullable: false),
                        EndDT = c.DateTime(),
                        ProjetId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projets", t => t.ProjetId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ProjetId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Taches", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Taches", "ProjetId", "dbo.Projets");
            DropForeignKey("dbo.Associations", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Associations", "Projet_Id", "dbo.Projets");
            DropIndex("dbo.Taches", new[] { "UserId" });
            DropIndex("dbo.Taches", new[] { "ProjetId" });
            DropIndex("dbo.Associations", new[] { "User_Id" });
            DropIndex("dbo.Associations", new[] { "Projet_Id" });
            DropTable("dbo.Taches");
            DropTable("dbo.Projets");
            DropTable("dbo.Associations");
        }
    }
}
