using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>()
           .HasKey(i => i.Name);

            modelBuilder.Entity<Account>()
                .HasIndex(a => a.Name)
                .IsUnique();

            modelBuilder.Entity<Contact>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Incident>()
                .HasMany(i => i.Accounts)
                .WithOne(a => a.Incident);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Contacts)
                .WithOne(c => c.Account);
        }
    }
}
