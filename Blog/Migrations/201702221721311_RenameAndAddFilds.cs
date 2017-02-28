namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameAndAddFilds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PostTitle", c => c.String());
            AddColumn("dbo.Posts", "PostText", c => c.String());
            AddColumn("dbo.Posts", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Posts", "ImageUrl", c => c.String());
            DropColumn("dbo.Posts", "BlogTitle");
            DropColumn("dbo.Posts", "BlogText");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "BlogText", c => c.String());
            AddColumn("dbo.Posts", "BlogTitle", c => c.String());
            DropColumn("dbo.Posts", "ImageUrl");
            DropColumn("dbo.Posts", "DateCreated");
            DropColumn("dbo.Posts", "PostText");
            DropColumn("dbo.Posts", "PostTitle");
        }
    }
}
