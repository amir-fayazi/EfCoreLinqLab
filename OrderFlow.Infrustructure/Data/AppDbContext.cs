

using Microsoft.EntityFrameworkCore;
using OrderFlow.Domain.Entities;

namespace OrderFlow.Infrustructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString =
            @"Server=.;Database=Week12-OrderFlowDb;Integrated Security=True;TrustServerCertificate=True;";

        public DbSet<Customer> customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(x => x.Fullname)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<Customer>()
                .HasIndex(x => x.Email)
                .IsUnique(); 

            modelBuilder.Entity<Product>()
           .Property(x => x.Name)
           .IsRequired()
           .HasMaxLength(120);

            modelBuilder.Entity<Product>()
                .Property(x => x.Price)
                .HasColumnType("decimal(18,2)");

            //------------------relation

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(or => or.OrderId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderItems)
                .WithOne(or => or.Product)
                .HasForeignKey(or => or.ProductId);

            //-----------------------Constraint
            modelBuilder.Entity<OrderItem>()
                .HasIndex(x => new { x.OrderId, x.ProductId })
                .IsUnique();


            
        }

    }
}
