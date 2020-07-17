namespace FireStats.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emergencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        WorkShiftId = c.Int(nullable: false),
                        Adress = c.String(),
                        СriterionEmergency = c.Boolean(nullable: false),
                        Applicant = c.String(),
                        FireObject = c.String(),
                        Owner = c.String(),
                        DamageResult = c.String(),
                        Leader = c.String(),
                        WorkTime_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkTimes", t => t.WorkTime_Id)
                .ForeignKey("dbo.WorkShifts", t => t.WorkShiftId, cascadeDelete: true)
                .Index(t => t.WorkShiftId)
                .Index(t => t.WorkTime_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserTypeId = c.Int(nullable: false),
                        Adress = c.String(),
                        Personnel = c.Int(nullable: false),
                        FireTruck = c.Int(nullable: false),
                        Emergency_Id = c.Int(),
                        Fire_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Emergencies", t => t.Emergency_Id)
                .ForeignKey("dbo.Fires", t => t.Fire_Id)
                .Index(t => t.UserTypeId)
                .Index(t => t.Emergency_Id)
                .Index(t => t.Fire_Id);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentData = c.DateTime(nullable: false),
                        CallTime = c.DateTime(nullable: false),
                        CheckOutTime = c.DateTime(nullable: false),
                        ArrivalTime = c.DateTime(nullable: false),
                        BarrelFeedTime = c.DateTime(nullable: false),
                        LocalizationTime = c.DateTime(nullable: false),
                        LiquidationTime = c.DateTime(nullable: false),
                        CollectionTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        WorkShiftId = c.Int(nullable: false),
                        Adress = c.String(),
                        FireRank = c.Byte(nullable: false),
                        Applicant = c.String(),
                        FireObject = c.String(),
                        Owner = c.String(),
                        DamageResult = c.String(),
                        CauseOfFire = c.String(),
                        CostOfDamage = c.Int(nullable: false),
                        CostOfSalvage = c.Int(nullable: false),
                        Leader = c.String(),
                        FireInspector = c.String(),
                        WorkTime_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkTimes", t => t.WorkTime_Id)
                .ForeignKey("dbo.WorkShifts", t => t.WorkShiftId, cascadeDelete: true)
                .Index(t => t.WorkShiftId)
                .Index(t => t.WorkTime_Id);
            
            CreateTable(
                "dbo.WorkShifts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CurrentData = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkShifts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Fires", "WorkShiftId", "dbo.WorkShifts");
            DropForeignKey("dbo.Emergencies", "WorkShiftId", "dbo.WorkShifts");
            DropForeignKey("dbo.Fires", "WorkTime_Id", "dbo.WorkTimes");
            DropForeignKey("dbo.Users", "Fire_Id", "dbo.Fires");
            DropForeignKey("dbo.Emergencies", "WorkTime_Id", "dbo.WorkTimes");
            DropForeignKey("dbo.Users", "Emergency_Id", "dbo.Emergencies");
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.WorkShifts", new[] { "UserId" });
            DropIndex("dbo.Fires", new[] { "WorkTime_Id" });
            DropIndex("dbo.Fires", new[] { "WorkShiftId" });
            DropIndex("dbo.Users", new[] { "Fire_Id" });
            DropIndex("dbo.Users", new[] { "Emergency_Id" });
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropIndex("dbo.Emergencies", new[] { "WorkTime_Id" });
            DropIndex("dbo.Emergencies", new[] { "WorkShiftId" });
            DropTable("dbo.WorkShifts");
            DropTable("dbo.Fires");
            DropTable("dbo.WorkTimes");
            DropTable("dbo.UserTypes");
            DropTable("dbo.Users");
            DropTable("dbo.Emergencies");
        }
    }
}
