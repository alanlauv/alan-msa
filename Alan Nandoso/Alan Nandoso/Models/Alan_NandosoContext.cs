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
    }
}
