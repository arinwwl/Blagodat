using Microsoft.EntityFrameworkCore;
using Blagodat.Model;

namespace Blagodat.Data;

public partial class BlagodatContext : DbContext
{
    public BlagodatContext()
    {
    }

    public BlagodatContext(DbContextOptions<BlagodatContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderService> OrderServices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=demotest1;Trusted_Connection=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clients__3213E83F12345678");

            entity.ToTable("clients");

            entity.HasIndex(e => e.Email, "UQ__clients__AB6E6167").IsUnique();

           
            entity.HasIndex(e => e.ClientCode, "UQ__clients__client_code").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientCode).HasColumnName("client_code"); 
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.MiddleName).HasColumnName("middle_name");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.PostalCode).HasColumnName("postal_code");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Password).HasColumnName("password");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__services__3213E83F12345678");

            entity.ToTable("services");

            entity.HasIndex(e => e.Code, "UQ__services__357D4CF9").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.PricePerHour)
                .HasColumnName("price_per_hour")
                .HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__orders__3213E83F12345678");

            entity.ToTable("orders");

            entity.HasIndex(e => e.OrderCode, "UQ__orders__F2C1A1C9").IsUnique();
            entity.HasIndex(e => e.Status, "IX_orders_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderCode).HasColumnName("order_code");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.ClientCode).HasColumnName("client_code");
            entity.Property(e => e.Services).HasColumnName("services");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.ClosedDate).HasColumnName("closed_date");
            entity.Property(e => e.RentalDuration).HasColumnName("rental_duration");

            entity.HasOne(d => d.Client)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientCode)        
                .HasPrincipalKey(c => c.ClientCode)       
                .HasConstraintName("FK_orders_clients");
        });

        modelBuilder.Entity<OrderService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order_se__3213E83F12345678");

            entity.ToTable("order_services");

            entity.HasIndex(e => e.OrderId, "IX_order_services_order_id");
            entity.HasIndex(e => e.ServiceId, "IX_order_services_service_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.PriceAtTime)
                .HasColumnName("price_at_time")
                .HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_order_services_orders");

            entity.HasOne(d => d.Service).WithMany(p => p.OrderServices)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_order_services_services");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}