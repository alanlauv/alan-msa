using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Alan_Nandoso.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class Alan_NandosoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Alan_NandosoContext() : base("name=Alan_NandosoContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Alan_NandosoContext, MyConfiguration>());
        }

        public System.Data.Entity.DbSet<Alan_Nandoso.Models.Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<Alan_Nandoso.Models.Reply> Replies { get; set; }


        public class MyConfiguration : DbMigrationsConfiguration<Alan_NandosoContext>
        {
            public MyConfiguration()
            {
                // enable migrations so db knows how to update based on model
                this.AutomaticMigrationsEnabled = true;

                this.AutomaticMigrationDataLossAllowed = true;
            }

            protected override void Seed(Alan_NandosoContext context)
            {
                var comments = new List<Comment>
                {
                    new Comment { Name = "Carson",    Body = "Comment 1", Date = DateTime.Parse("2010-09-01") },
                    new Comment { Name = "Alexander", Body = "COmment 2", Date = DateTime.Parse("2012-09-01") }
                };
                comments.ForEach(c => context.Comments.AddOrUpdate(p => p.Name, c));
                context.SaveChanges();

                var replies = new List<Reply>
                {
                    new Reply {Name = "Abra", Body = "Reply 1", Date = DateTime.Parse("2010-09-01"), CommentID = comments.Single(c => c.Name == "Carson").ID },
                    new Reply {Name = "James", Body = "Reply 2", Date = DateTime.Parse("2010-09-02"), CommentID = comments.Single(c => c.Name == "Carson").ID },
                    new Reply {Name = "Dixon", Body = "Reply 3", Date = DateTime.Parse("2010-09-02"), CommentID = comments.Single(c => c.Name == "Alexander").ID },
                };

                foreach (Reply r in replies)
                {
                    var replyInDataBase = context.Replies.Where(
                        s => s.Comment.ID == r.CommentID).SingleOrDefault();
                    if (replyInDataBase == null)
                    {
                        context.Replies.Add(r);
                    }
                }
                context.SaveChanges();
            }
        }
    
    }
}
