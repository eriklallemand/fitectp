namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartDateInCourseTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "StartDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Course", "StartDate");
        }
    }
}
