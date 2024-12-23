
using ETicaret.Entities.Configuration.Abstract;
using ETicaretEntity.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

public class WebDbContext : DbContext
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Log> Logs { get; set; }
    public DbSet<SiteSetting> SiteSettings { get; set; }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }

    public DbSet<Payment> Payments { get; set; }

    public DbSet<Product> Product { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    public WebDbContext()
    {

    }

    public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("server=.;Database=ETicaretDB;Trusted_Connection=true;TrustServerCertificate=true");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseConfig<>).Assembly);

    }
}



