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
        public DbSet<PhieuYeuCau> PhieuYeuCaus { get; set; }
        public DbSet<MauLayHienTruong> MauLayHienTruongs { get; set; }
        public DbSet<SoNhanMau> SoNhanMaus { get; set; }
        public DbSet<SoChuyenMau> SoChuyenMaus { get; set; }
        public DbSet<SoKQThuNghiem> SoKQThuNghiems { get; set; }
        public DbSet<FormKQ> FormKQs { get; set; }
        public DbSet<CacSoNhanMau> CacSoNhanMaus { get; set; }
        public DbSet<CacSoChuyenMau> CacSoChuyenMaus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // khai báo Id sẽ là khóa chính
            modelBuilder.Entity<User>().HasKey(b => b.Id);
            // khai báo Id sẽ tự động tăng
            modelBuilder.Entity<User>().Property(b => b.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);

            // khai báo Id sẽ là khóa chính
            modelBuilder.Entity<PhieuYeuCau>().HasKey(b => b.Id);
            // khai báo Id sẽ tự động tăng
            modelBuilder.Entity<PhieuYeuCau>().Property(b => b.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);
      
            // khai báo Id sẽ là khóa chính
            modelBuilder.Entity<MauLayHienTruong>().HasKey(b => b.Id);
            // khai báo Id sẽ tự động tăng
            modelBuilder.Entity<MauLayHienTruong>().Property(b => b.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);

            // khai báo Id sẽ là khóa chính
            modelBuilder.Entity<SoNhanMau>().HasKey(b => b.Id);
            // khai báo Id sẽ tự động tăng
            modelBuilder.Entity<SoNhanMau>().Property(b => b.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);

            // khai báo Id sẽ là khóa chính
            modelBuilder.Entity<CacSoNhanMau>().HasKey(b => b.Id);
            // khai báo Id sẽ tự động tăng
            modelBuilder.Entity<CacSoNhanMau>().Property(b => b.Id)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);
        }
    }
}