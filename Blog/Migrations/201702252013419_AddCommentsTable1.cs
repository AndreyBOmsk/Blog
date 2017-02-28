namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentsTable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropPrimaryKey("dbo.Posts");
            AlterColumn("dbo.Comments", "PostId", c => c.Long(nullable: false));
            AlterColumn("dbo.Posts", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Posts", "Id");
            CreateIndex("dbo.Comments", "PostId");
            AddForeignKey("dbo.Comments", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropPrimaryKey("dbo.Posts");
            AlterColumn("dbo.Posts", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Comments", "PostId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Posts", "Id");
            CreateIndex("dbo.Comments", "PostId");
            AddForeignKey("dbo.Comments", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
    }
}
