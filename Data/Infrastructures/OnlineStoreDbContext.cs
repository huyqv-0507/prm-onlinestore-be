using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Infrastructures
{
    public class OnlineStoreDbContext : DbContext
    {
        public OnlineStoreDbContext()
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=OnlineStoreDatabase;User=sa;Pwd=Password0507;Trusted_Connection=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Brand
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(prop => prop.BrandName)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.HasMany(shoe => shoe.Shoes)
                    .WithOne(brand => brand.Brand)
                    .HasForeignKey(key => key.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Brand_Order");
            });
            #endregion
            #region Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(prop => prop.DateCreated)
                    .HasColumnType("datetime")
                    .IsRequired();
                entity.Property(prop => prop.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(prop => prop.Quantity)
                    .HasColumnType("int")
                    .IsRequired();
                entity.Property(prop => prop.TotalPrice)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
                entity.Property(prop => prop.Username)
                    .IsRequired()
                    .HasMaxLength(20);
                entity.HasMany(od => od.OrderDetails)
                    .WithOne(order => order.Order)
                    .HasForeignKey(key => key.OrderDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_OrderDetail");
                entity.HasOne(user => user.User)
                    .WithMany(order => order.Orders)
                    .HasForeignKey(key => key.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_User");
            });
            #endregion
            #region OrderDetail
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(prop => prop.OrderId)
                    .IsRequired()
                    .HasColumnType("int");
                entity.Property(prop => prop.Price)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
                entity.Property(prop => prop.ShoeId)
                    .IsRequired()
                    .HasColumnType("int");
                entity.Property(prop => prop.Username)
                    .IsRequired()
                    .HasMaxLength(20);
            });
            #endregion
            #region Role
            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(prop => prop.RoleName)
                    .HasMaxLength(20)
                    .IsRequired();
            });
            #endregion
            #region Shoe
            modelBuilder.Entity<Shoe>(entity =>
            {
                entity.Property(prop => prop.ShoesName)
                    .HasMaxLength(100)
                    .IsRequired();
                entity.Property(prop => prop.Title)
                    .HasMaxLength(500)
                    .IsRequired();
                entity.Property(prop => prop.Size)
                    .HasMaxLength(1000)
                    .IsRequired();
                entity.Property(prop => prop.Price)
                    .IsRequired()
                    .HasColumnType("decimal(18, 2)");
                entity.Property(prop => prop.Color)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");
                entity.Property(prop => prop.Description)
                    .HasColumnType("nvarchar(max)")
                    .IsUnicode(false);
                entity.Property(prop => prop.BrandId)
                    .IsRequired()
                    .HasColumnType("int");

                entity.HasMany(od => od.OrderDetails)
                    .WithOne(shoe => shoe.Shoe)
                    .HasForeignKey(key => key.ShoeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shoe_OrderDetails");
            });
            #endregion

            #region Store
            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(prop => prop.Address)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(500);
                
            });
            #endregion User
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(prop => prop.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .ValueGeneratedNever();
                entity.Property(prop => prop.FullName)
                    .HasMaxLength(100)
                    .IsRequired()
                    .IsUnicode(false);
                entity.Property(prop => prop.Password)
                    .IsRequired()
                    .HasMaxLength(20);
                entity.Property(prop => prop.RoleId)
                    .IsRequired()
                    .HasColumnType("int");
                entity.Property(prop => prop.Status)
                    .IsRequired()
                    .HasColumnType("bit");
                entity.HasKey(key => key.Username);
                entity.HasOne(role => role.Role)
                    .WithMany(user => user.Users)
                    .HasForeignKey(key => key.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
                entity.HasOne(store => store.Store)
                    .WithMany(user => user.Users)
                    .HasForeignKey(key => key.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Store");
            });
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Shoe> Shoes { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<User> Users { get; set; }


        public void Commit()
        {
            base.SaveChanges();
        }
    }

    
}
