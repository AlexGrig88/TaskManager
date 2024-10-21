using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Models;
using TaskManager.Common.Models.Enums;

namespace TaskManager.Api.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Desk> Desks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectAdmin> ProjectAdmins { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
            if (!Users?.Any(u => u.Status == UserStatus.Admin) ?? false) {
                var admin = new User("Maxim", "Petrov", "petrow@gmail.com", "qwerty", UserStatus.Admin);
                Users.Add(admin);
                SaveChanges();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
/*            modelBuilder.Entity<Desk>()
                 .HasOne(d => d.Admin)
                 .WithMany(u => u.Desks)
                 .HasForeignKey(d => d.AdminId);*/

        }
    }
}
