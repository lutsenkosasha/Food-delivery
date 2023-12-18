using FoodDelivery.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.DataAccess;

public class FoodDeliveryDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<DeliveryEntity> Deliveries { get; set; }
    public DbSet<AdminEntity> Admins { get; set; }
    public DbSet<DishEntity> Dishes { get; set; }
    public DbSet<DishInOrderEntity> DishesInOrders { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }

    public FoodDeliveryDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<UserEntity>().HasOne(x => x.Delivery)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.DeliveryId);
        modelBuilder.Entity<UserEntity>().HasOne(x => x.Admin)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.AdminID);

        modelBuilder.Entity<DeliveryEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<DeliveryEntity>().HasIndex(x => x.ExternalId).IsUnique();

        modelBuilder.Entity<AdminEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<AdminEntity>().HasIndex(x => x.ExternalId).IsUnique();

        modelBuilder.Entity<DishEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<DishEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<DishEntity>().HasOne(x => x.Admin)
            .WithMany(x => x.Dishes)
            .HasForeignKey(x => x.AdminID);
        modelBuilder.Entity<DishEntity>().HasOne(x => x.DishInOrder)
            .WithMany(x => x.Dishes)
            .HasForeignKey(x => x.DishInOrderID);

        modelBuilder.Entity<DishInOrderEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<DishInOrderEntity>().HasIndex(x => x.ExternalId).IsUnique();

        modelBuilder.Entity<OrderEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<OrderEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<OrderEntity>().HasOne(x => x.Admin)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.AdminID);
        modelBuilder.Entity<OrderEntity>().HasOne(x => x.DishInOrder)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.DishInOrderID);
        modelBuilder.Entity<OrderEntity>().HasOne(x => x.User)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.UserID);
    }
}
