namespace DataStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Distributor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(nullable: false),
                        City = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DistributorTable",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VehicleID = c.Int(nullable: false),
                        DistributorID = c.Int(nullable: false),
                        Month = c.Int(),
                        YearInputID = c.Int(nullable: false),
                        Realization = c.Int(nullable: false),
                        PriceOfCostOfProduct = c.Int(nullable: false),
                        Gratis = c.Int(nullable: false),
                        Shortage = c.Int(nullable: false),
                        Storage = c.Int(nullable: false),
                        Unload = c.Int(nullable: false),
                        Commercialist = c.Int(nullable: false),
                        BrutoPay = c.Int(nullable: false),
                        BrutoPercent = c.Int(nullable: false),
                        NetoPay = c.Int(nullable: false),
                        NetoPercent = c.Int(nullable: false),
                        Fuel = c.Int(nullable: false),
                        Service = c.Int(nullable: false),
                        Consumables = c.Int(nullable: false),
                        RegistrationInsurance = c.Int(nullable: false),
                        OtherExpenses = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Distributor", t => t.DistributorID, cascadeDelete: true)
                .ForeignKey("dbo.Vehicle", t => t.VehicleID, cascadeDelete: true)
                .ForeignKey("dbo.YearInput", t => t.YearInputID, cascadeDelete: true)
                .Index(t => t.VehicleID)
                .Index(t => t.DistributorID)
                .Index(t => t.YearInputID);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Registration = c.String(nullable: false),
                        CarBrand = c.String(nullable: false),
                        CarModel = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.YearInput",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Year = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DistributorTable", "YearInputID", "dbo.YearInput");
            DropForeignKey("dbo.DistributorTable", "VehicleID", "dbo.Vehicle");
            DropForeignKey("dbo.DistributorTable", "DistributorID", "dbo.Distributor");
            DropIndex("dbo.DistributorTable", new[] { "YearInputID" });
            DropIndex("dbo.DistributorTable", new[] { "DistributorID" });
            DropIndex("dbo.DistributorTable", new[] { "VehicleID" });
            DropTable("dbo.YearInput");
            DropTable("dbo.Vehicle");
            DropTable("dbo.DistributorTable");
            DropTable("dbo.Distributor");
        }
    }
}
