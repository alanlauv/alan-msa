using Alan_Nandoso.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Alan_Nandoso.Models
{
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

        public System.Data.Entity.DbSet<Alan_Nandoso.Model.Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<Alan_Nandoso.Model.Reply> Replies { get; set; }

        public class MyConfiguration : DbMigrationsConfiguration<Alan_NandosoContext>
        {
            public MyConfiguration()
            {
                // enable migrations so db knows how to update based on model
                this.AutomaticMigrationsEnabled = true;

                this.AutomaticMigrationDataLossAllowed = true;
            }
        }

        protected override void Seed(Alan_NandosoContext context)
        {
            {
                new Student { FirstMidName = "Carson",   LastName = "Alexander",
                    EnrollmentDate = DateTime.Parse("2010-09-01") },
                new Student { FirstMidName = "Meredith", LastName = "Alonso",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Arturo",   LastName = "Anand",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Gytis",    LastName = "Barzdukas",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Yan",      LastName = "Li",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Peggy",    LastName = "Justice",
                    EnrollmentDate = DateTime.Parse("2011-09-01") },
                new Student { FirstMidName = "Laura",    LastName = "Norman",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Nino",     LastName = "Olivetto",
                    EnrollmentDate = DateTime.Parse("2005-08-11")}
            };
            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();
        }
    }
}
