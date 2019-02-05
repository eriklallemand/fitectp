namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthenticationLoginPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "Login", c => c.String(maxLength: 50));
            AddColumn("dbo.Person", "Password", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "Password");
            DropColumn("dbo.Person", "Login");
        }
    }
}
