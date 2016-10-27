namespace TaskList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataAnnotations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lists", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Lists", "ListName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.TodoTasks", "Task", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TodoTasks", "Task", c => c.String());
            AlterColumn("dbo.Lists", "ListName", c => c.String());
            DropColumn("dbo.Lists", "DateCreated");
        }
    }
}
