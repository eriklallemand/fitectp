namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class merged_from_student_api : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseOccurrence",
                c => new
                    {
                        CourseOccurrenceID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        DayOfWeek = c.Int(nullable: false),
                        StartingHour = c.Int(nullable: false),
                        StartingMinute = c.Int(nullable: false),
                        DurationMinutes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseOccurrenceID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);

            AddColumn("dbo.Course", "StartDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseOccurrence", "CourseID", "dbo.Course");
            DropIndex("dbo.CourseOccurrence", new[] { "CourseID" });
            DropColumn("dbo.Course", "StartDate");
            DropTable("dbo.CourseOccurrence");
        }
    }
}
