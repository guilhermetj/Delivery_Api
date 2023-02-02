using Delivery_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Delivery_Api.Data
{
    public class DeliveryDBContext : DbContext
    {
        public DeliveryDBContext(DbContextOptions<DeliveryDBContext> options) : base(options) { }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Products>().ToTable("tb_products");
            modelBuilder.Entity<Products>().HasKey(p => p.Id);
            modelBuilder.Entity<Products>().Property(p => p.Id).HasColumnName("id").IsRequired();
            modelBuilder.Entity<Products>().Property(p => p.Price).HasColumnName("price").IsRequired();
            modelBuilder.Entity<Products>().Property(p => p.Name).HasColumnName("name").IsRequired();
            modelBuilder.Entity<Products>().Property(p => p.Description).HasColumnName("description").IsRequired();
            modelBuilder.Entity<Products>().Property(p => p.Image).HasColumnName("image").IsRequired();

            modelBuilder.Entity<Payment>().ToTable("tb_payment");
            modelBuilder.Entity<Payment>().HasKey(p => p.Id);
            modelBuilder.Entity<Payment>().Property(p => p.Id).HasColumnName("id").IsRequired();
            modelBuilder.Entity<Payment>().Property(p => p.Name).HasColumnName("name").IsRequired();
            modelBuilder.Entity<Payment>().Property(p => p.Acronym).HasColumnName("acromyn").IsRequired();
            modelBuilder.Entity<Payment>().Property(p => p.Enabled).HasColumnName("enabled").IsRequired();

        }
    }
}
