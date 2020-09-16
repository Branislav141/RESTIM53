namespace Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrvaMigracija : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Resurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Opis = c.String(),
                        TipResursa_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tips", t => t.TipResursa_Id)
                .Index(t => t.TipResursa_Id);
            
            CreateTable(
                "dbo.Tips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipVezes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vezas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPrvogElementa = c.Int(nullable: false),
                        IdDrugogElementa = c.Int(nullable: false),
                        TipV_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipVezes", t => t.TipV_Id)
                .Index(t => t.TipV_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vezas", "TipV_Id", "dbo.TipVezes");
            DropForeignKey("dbo.Resurs", "TipResursa_Id", "dbo.Tips");
            DropIndex("dbo.Vezas", new[] { "TipV_Id" });
            DropIndex("dbo.Resurs", new[] { "TipResursa_Id" });
            DropTable("dbo.Vezas");
            DropTable("dbo.TipVezes");
            DropTable("dbo.Tips");
            DropTable("dbo.Resurs");
        }
    }
}
