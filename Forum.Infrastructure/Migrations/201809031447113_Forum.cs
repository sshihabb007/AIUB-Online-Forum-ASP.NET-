namespace Forum.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Forum : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Change_Info_Request", "user_id");
            CreateIndex("dbo.Comments", "user_id");
            CreateIndex("dbo.Comments", "post_id");
            CreateIndex("dbo.Posts", "user_id");
            CreateIndex("dbo.Comment_Vote", "user_id");
            CreateIndex("dbo.Comment_Vote", "comment_id");
            CreateIndex("dbo.Complains", "from_user");
            CreateIndex("dbo.Complains", "to_user");
            CreateIndex("dbo.Complain_Reply", "complain_id");
            CreateIndex("dbo.Complain_Reply", "user_id");
            CreateIndex("dbo.Post_Vote", "user_id");
            CreateIndex("dbo.Post_Vote", "post_id");
            CreateIndex("dbo.Rankings", "user_id");
            CreateIndex("dbo.Replies", "user_id");
            CreateIndex("dbo.Replies", "comment_id");
            CreateIndex("dbo.Reply_Vote", "user_id");
            CreateIndex("dbo.Reply_Vote", "reply_id");
            AddForeignKey("dbo.Change_Info_Request", "user_id", "dbo.Users", "user_id", cascadeDelete: false);
            AddForeignKey("dbo.Posts", "user_id", "dbo.Users", "user_id", cascadeDelete: false);
            AddForeignKey("dbo.Comments", "post_id", "dbo.Posts", "post_id", cascadeDelete: false);
            AddForeignKey("dbo.Comments", "user_id", "dbo.Users", "user_id", cascadeDelete: false);
            AddForeignKey("dbo.Comment_Vote", "comment_id", "dbo.Comments", "comment_id", cascadeDelete: false);
            AddForeignKey("dbo.Comment_Vote", "user_id", "dbo.Users", "user_id", cascadeDelete: false);
            AddForeignKey("dbo.Complains", "from_user", "dbo.Users", "user_id", cascadeDelete: false);
            AddForeignKey("dbo.Complains", "to_user", "dbo.Users", "user_id", cascadeDelete: false);
            AddForeignKey("dbo.Complain_Reply", "complain_id", "dbo.Complains", "complain_id", cascadeDelete: false);
            AddForeignKey("dbo.Complain_Reply", "user_id", "dbo.Users", "user_id", cascadeDelete: false);
            AddForeignKey("dbo.Post_Vote", "post_id", "dbo.Posts", "post_id", cascadeDelete: false);
            AddForeignKey("dbo.Post_Vote", "user_id", "dbo.Users", "user_id", cascadeDelete: false);
            AddForeignKey("dbo.Rankings", "user_id", "dbo.Users", "user_id", cascadeDelete: false);
            AddForeignKey("dbo.Replies", "comment_id", "dbo.Comments", "comment_id", cascadeDelete: false);
            AddForeignKey("dbo.Replies", "user_id", "dbo.Users", "user_id", cascadeDelete: false);
            AddForeignKey("dbo.Reply_Vote", "reply_id", "dbo.Replies", "reply_id", cascadeDelete: false);
            AddForeignKey("dbo.Reply_Vote", "user_id", "dbo.Users", "user_id", cascadeDelete: false);
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
            DropIndex("dbo.Complain_Reply", new[] { "user_id" });
            DropIndex("dbo.Complain_Reply", new[] { "complain_id" });
            DropIndex("dbo.Complains", new[] { "to_user" });
            DropIndex("dbo.Complains", new[] { "from_user" });
            DropIndex("dbo.Comment_Vote", new[] { "comment_id" });
            DropIndex("dbo.Comment_Vote", new[] { "user_id" });
            DropIndex("dbo.Posts", new[] { "user_id" });
            DropIndex("dbo.Comments", new[] { "post_id" });
            DropIndex("dbo.Comments", new[] { "user_id" });
            DropIndex("dbo.Change_Info_Request", new[] { "user_id" });
        }
    }
}
