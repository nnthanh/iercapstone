using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.Administrator.Models
{
    public class IERSystemDBContext : DbContext
    {
        public IERSystemDBContext()
            : base("name=IERSystemDBContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<MauLayHienTruong> MauLayHienTruong { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // khai báo Id sẽ là khóa chính
            modelBuilder.Entity<User>().HasKey(b => b.Id);

            // khai báo Id sẽ tự động tăng
            modelBuilder.Entity<User>().Property(b => b.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);

            // khai báo Id sẽ là khóa chính
            modelBuilder.Entity<Request>().HasKey(b => b.Id);

            // khai báo Id sẽ tự động tăng
            modelBuilder.Entity<Request>().Property(b => b.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);


            // khai báo Id sẽ là khóa chính
            modelBuilder.Entity<MauLayHienTruong>().HasKey(b => b.Id);

            // khai báo Id sẽ tự động tăng
            modelBuilder.Entity<MauLayHienTruong>().Property(b => b.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);
        }
    }
}