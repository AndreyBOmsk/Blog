namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBadWordsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BadWords",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Word = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BadWords");
        }
    }
}
