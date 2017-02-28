namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriorityToPosts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Priority", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Priority");
        }
    }
}
