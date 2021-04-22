using Microsoft.EntityFrameworkCore;
using sabs_app_api.Models;

namespace sabs_app_api.Infrastructure
{

    public sealed class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<IPAdress> IPs { get; set; }
        public DbSet<PendingAdresses> PendingAdresses { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();

        }

        public Context()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
