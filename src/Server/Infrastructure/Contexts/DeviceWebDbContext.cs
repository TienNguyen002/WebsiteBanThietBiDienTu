using Domain.Entities;
using Infrastructure.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class DeviceWebDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }

        public DeviceWebDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DeviceWeb;Trusted_Connection=True;Encrypt=False;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BranchMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ColorMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommentMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiscountMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ImageMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderItemMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PaymentMethodMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoleMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SaleMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SerieMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StatusMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserMap).Assembly);
        }
    }
}
