namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingCourseOccurrenceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseOccurrence",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        Day = c.String(),
                        Hour = c.Int(nullable: false),
                        Minute = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        Course_CourseID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.Course_CourseID)
                .Index(t => t.Course_CourseID);
            
            AddColumn("dbo.Course", "CourseOccurrence_ID", c => c.Int());
            CreateIndex("dbo.Course", "CourseOccurrence_ID");
            AddForeignKey("dbo.Course", "CourseOccurrence_ID", "dbo.CourseOccurrence", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Course", "CourseOccurrence_ID", "dbo.CourseOccurrence");
            DropForeignKey("dbo.CourseOccurrence", "Course_CourseID", "dbo.Course");
            DropIndex("dbo.Course", new[] { "CourseOccurrence_ID" });
            DropIndex("dbo.CourseOccurrence", new[] { "Course_CourseID" });
            DropColumn("dbo.Course", "CourseOccurrence_ID");
            DropTable("dbo.CourseOccurrence");
        }
    }
}
