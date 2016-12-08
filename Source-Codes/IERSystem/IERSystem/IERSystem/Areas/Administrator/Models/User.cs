using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.Administrator.Models
{
    public class User
    {
        public int Id { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public String fullname { get; set; }
    }
    public class IERSystemDBContext : DbContext
    {
        public IERSystemDBContext()
            : base("name=IERSystemDBContext")
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // khai báo Id sẽ là khóa chính
            modelBuilder.Entity<User>().HasKey(b => b.Id);

            // khai báo Id sẽ tự động tăng
            modelBuilder.Entity<User>().Property(b => b.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);
        }
    }
}