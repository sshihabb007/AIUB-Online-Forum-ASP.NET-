namespace Forum.Admin.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class u1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Change_Info_Request",
                c => new
                    {
                        request_id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        field_name = c.Int(nullable: false),
                        field_value = c.String(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.request_id)
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        user_id = c.Int(nullable: false, identity: true),
                        user_type = c.Int(nullable: false),
                        user_name = c.String(nullable: false),
                        password = c.String(nullable: false),
                        full_name = c.String(nullable: false),
                        email = c.String(nullable: false),
                        phone = c.String(nullable: false),
                        cgpa = c.Double(nullable: false),
                        department = c.Int(nullable: false),
                        dateOfBirth = c.DateTime(nullable: false),
                        gender = c.Int(nullable: false),
                        blood_group = c.Int(nullable: false),
                        religion = c.String(nullable: false),
                        address = c.String(),
                        photo = c.String(),
                        status = c.Int(nullable: false),
                        last_login = c.DateTime(nullable: false),
                        last_logout = c.DateTime(nullable: false),
                        last_posted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.user_id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        comment_id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        post_id = c.Int(nullable: false),
                        comment = c.String(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.comment_id)
                .ForeignKey("dbo.Posts", t => t.post_id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: false)
                .Index(t => t.user_id)
                .Index(t => t.post_id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        post_id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        title = c.String(nullable: false),
                        body = c.String(nullable: false),
                        tags = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                        status = c.Int(nullable: false),
                        activity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.post_id)
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.Comment_Vote",
                c => new
                    {
                        vote_id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        comment_id = c.Int(nullable: false),
                        vote_status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.vote_id)
                .ForeignKey("dbo.Comments", t => t.comment_id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: false)
                .Index(t => t.user_id)
                .Index(t => t.comment_id);
            
            CreateTable(
                "dbo.Complain_Reply",
                c => new
                    {
                        complain_reply_id = c.Int(nullable: false, identity: true),
                        complain_id = c.Int(nullable: false),
                        user_id = c.Int(nullable: false),
                        reply = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.complain_reply_id)
                .ForeignKey("dbo.Complains", t => t.complain_id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: false)
                .Index(t => t.complain_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.Complains",
                c => new
                    {
                        complain_id = c.Int(nullable: false, identity: true),
                        from_user = c.Int(nullable: false),
                        to_user = c.Int(nullable: false),
                        complain = c.String(nullable: false),
                        description = c.String(nullable: false),
                        status = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        notification = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.complain_id)
                .ForeignKey("dbo.Users", t => t.from_user, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.to_user, cascadeDelete: false)
                .Index(t => t.from_user)
                .Index(t => t.to_user);
            
            CreateTable(
                "dbo.Post_Vote",
                c => new
                    {
                        vote_id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        post_id = c.Int(nullable: false),
                        vote_status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.vote_id)
                .ForeignKey("dbo.Posts", t => t.post_id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: false)
                .Index(t => t.user_id)
                .Index(t => t.post_id);
            
            CreateTable(
                "dbo.Rankings",
                c => new
                    {
                        ranking_id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ranking_id)
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        reply_id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        comment_id = c.Int(nullable: false),
                        reply = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.reply_id)
                .ForeignKey("dbo.Comments", t => t.comment_id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: false)
                .Index(t => t.user_id)
                .Index(t => t.comment_id);
            
            CreateTable(
                "dbo.Reply_Vote",
                c => new
                    {
                        vote_id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        reply_id = c.Int(nullable: false),
                        vote_status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.vote_id)
                .ForeignKey("dbo.Replies", t => t.reply_id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: false)
                .Index(t => t.user_id)
                .Index(t => t.reply_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reply_Vote", "user_id", "dbo.Users");
            DropForeignKey("dbo.Reply_Vote", "reply_id", "dbo.Replies");
            DropForeignKey("dbo.Replies", "user_id", "dbo.Users");
            DropForeignKey("dbo.Replies", "comment_id", "dbo.Comments");
            DropForeignKey("dbo.Rankings", "user_id", "dbo.Users");
            DropForeignKey("dbo.Post_Vote", "user_id", "dbo.Users");
            DropForeignKey("dbo.Post_Vote", "post_id", "dbo.Posts");
            DropForeignKey("dbo.Complain_Reply", "user_id", "dbo.Users");
            DropForeignKey("dbo.Complain_Reply", "complain_id", "dbo.Complains");
            DropForeignKey("dbo.Complains", "to_user", "dbo.Users");
            DropForeignKey("dbo.Complains", "from_user", "dbo.Users");
            DropForeignKey("dbo.Comment_Vote", "user_id", "dbo.Users");
            DropForeignKey("dbo.Comment_Vote", "comment_id", "dbo.Comments");
            DropForeignKey("dbo.Comments", "user_id", "dbo.Users");
            DropForeignKey("dbo.Comments", "post_id", "dbo.Posts");
            DropForeignKey("dbo.Posts", "user_id", "dbo.Users");
            DropForeignKey("dbo.Change_Info_Request", "user_id", "dbo.Users");
            DropIndex("dbo.Reply_Vote", new[] { "reply_id" });
            DropIndex("dbo.Reply_Vote", new[] { "user_id" });
            DropIndex("dbo.Replies", new[] { "comment_id" });
            DropIndex("dbo.Replies", new[] { "user_id" });
            DropIndex("dbo.Rankings", new[] { "user_id" });
            DropIndex("dbo.Post_Vote", new[] { "post_id" });
            DropIndex("dbo.Post_Vote", new[] { "user_id" });
            DropIndex("dbo.Complains", new[] { "to_user" });
            DropIndex("dbo.Complains", new[] { "from_user" });
            DropIndex("dbo.Complain_Reply", new[] { "user_id" });
            DropIndex("dbo.Complain_Reply", new[] { "complain_id" });
            DropIndex("dbo.Comment_Vote", new[] { "comment_id" });
            DropIndex("dbo.Comment_Vote", new[] { "user_id" });
            DropIndex("dbo.Posts", new[] { "user_id" });
            DropIndex("dbo.Comments", new[] { "post_id" });
            DropIndex("dbo.Comments", new[] { "user_id" });
            DropIndex("dbo.Change_Info_Request", new[] { "user_id" });
            DropTable("dbo.Reply_Vote");
            DropTable("dbo.Replies");
            DropTable("dbo.Rankings");
            DropTable("dbo.Post_Vote");
            DropTable("dbo.Complains");
            DropTable("dbo.Complain_Reply");
            DropTable("dbo.Comment_Vote");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.Users");
            DropTable("dbo.Change_Info_Request");
        }
    }
}
