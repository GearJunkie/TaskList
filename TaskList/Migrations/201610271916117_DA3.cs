namespace TaskList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DA3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TodoTasks", "Task", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TodoTasks", "Task", c => c.String(nullable: false));
        }
    }
}
