namespace TaskList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        ListID = c.Int(nullable: false, identity: true),
                        ListName = c.String(),
                    })
                .PrimaryKey(t => t.ListID);
            
            CreateTable(
                "dbo.TodoTasks",
                c => new
                    {
                        TodoTaskID = c.Int(nullable: false, identity: true),
                        Task = c.String(),
                        ListID = c.Int(nullable: false),
                        completed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TodoTaskID)
                .ForeignKey("dbo.Lists", t => t.ListID, cascadeDelete: true)
                .Index(t => t.ListID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TodoTasks", "ListID", "dbo.Lists");
            DropIndex("dbo.TodoTasks", new[] { "ListID" });
            DropTable("dbo.TodoTasks");
            DropTable("dbo.Lists");
        }
    }
}
