namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeOccurrenceIdAutoincrement : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CourseOccurrence");
            AlterColumn("dbo.CourseOccurrence", "CourseOccurrenceID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CourseOccurrence", "CourseOccurrenceID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CourseOccurrence");
            AlterColumn("dbo.CourseOccurrence", "CourseOccurrenceID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CourseOccurrence", "CourseOccurrenceID");
        }
    }
}
