using Microsoft.EntityFrameworkCore;
using CarRentService.DataAccess.Entities;

namespace CarRentService.DataAccess;

public class CarRentDbContext : DbContext
{
    public CarRentDbContext(DbContextOptions<CarRentDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<UserSubscription> UserSubscriptions { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<LoyaltyProgram> LoyaltyPrograms { get; set; }
    public DbSet<CarMaintenance> CarMaintenances { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Уникальный индекс для пары (UserId, SubscriptionId) в UserSubscription
        modelBuilder.Entity<UserSubscription>()
            .HasIndex(us => new { us.UserId, us.SubscriptionId })
            .IsUnique();

        // Уникальность email и телефона в User
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Phone)
            .IsUnique();

        // Уникальность номерного знака и VIN в Car
        modelBuilder.Entity<Car>()
            .HasIndex(c => c.LicensePlate)
            .IsUnique();

        modelBuilder.Entity<Car>()
            .HasIndex(c => c.VIN)
            .IsUnique();

        // Настройка связей для Rental
        modelBuilder.Entity<Rental>()
            .HasOne(r => r.User)
            .WithMany(u => u.Rentals)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Rental>()
            .HasOne(r => r.Car)
            .WithMany(c => c.Rentals)
            .HasForeignKey(r => r.CarId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Rental>()
            .HasOne(r => r.UserSubscription)
            .WithMany(us => us.Rentals)
            .HasForeignKey(r => r.UserSubscriptionId)
            .IsRequired(false); // Может быть NULL

        // Настройка связей для UserSubscription (связи с User и Subscription)
        modelBuilder.Entity<UserSubscription>()
            .HasOne(us => us.User)
            .WithMany(u => u.UserSubscriptions)
            .HasForeignKey(us => us.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserSubscription>()
            .HasOne(us => us.Subscription)
            .WithMany(s => s.UserSubscriptions)
            .HasForeignKey(us => us.SubscriptionId)
            .OnDelete(DeleteBehavior.Restrict);

        // Настройка связи для CarMaintenance
        modelBuilder.Entity<CarMaintenance>()
            .HasOne(cm => cm.Car)
            .WithMany(c => c.Maintenances)
            .HasForeignKey(cm => cm.CarId)
            .OnDelete(DeleteBehavior.Restrict);

        // Настройка связи для User с LoyaltyProgram (опционально)
        modelBuilder.Entity<User>()
            .HasOne(u => u.LoyaltyProgram)
            .WithMany(lp => lp.Users)
            .HasForeignKey(u => u.LoyaltyProgramId)
            .OnDelete(DeleteBehavior.SetNull); // При удалении программы лояльности ссылка сбрасывается

        // Точность для decimal свойств
        modelBuilder.Entity<Car>()
            .Property(c => c.DailyRate)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Rental>()
            .Property(r => r.TotalCost)
            .HasPrecision(10, 2);

        modelBuilder.Entity<LoyaltyProgram>()
            .Property(lp => lp.DiscountPercent)
            .HasPrecision(5, 2);

        modelBuilder.Entity<CarMaintenance>()
            .Property(cm => cm.Cost)
            .HasPrecision(10, 2);
    }
}