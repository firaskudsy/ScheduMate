namespace ScheduMate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployerClassAddes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Mobile = c.String(),
                        Email = c.String(),
                        Rate = c.Byte(nullable: false),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employers");
        }
    }
}
