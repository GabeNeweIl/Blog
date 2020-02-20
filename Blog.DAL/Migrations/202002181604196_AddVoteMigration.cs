namespace Blog.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVoteMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Votes");
        }
    }
}
