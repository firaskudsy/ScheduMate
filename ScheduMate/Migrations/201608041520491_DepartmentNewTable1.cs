namespace ScheduMate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentNewTable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "Department", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "Department", c => c.String());
        }
    }
}
