namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentApi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentDTO",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        lastname = c.String(),
                        firstname = c.String(),
                        enrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentDTO");
        }
    }
}
