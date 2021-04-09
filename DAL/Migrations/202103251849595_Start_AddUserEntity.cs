namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start_AddUserEntity : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.Users", "Nickname", c => c.String(nullable: false));
            //AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            //AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Nickname", c => c.String());
        }
    }
}
