namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INeedToDoMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentDTO", "enrollmentDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentDTO", "enrollmentDate", c => c.DateTime(nullable: false));
        }
    }
}
