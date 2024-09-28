using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Models;

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
            if (!Users.Any(u => u.Status == UserStatus.Admin)) {
                Users.Add(new User("Pavel", "Popov", "pavpop111@gmail.com", "123qwerty", UserStatus.Admin));
                SaveChanges();
            }
        }
    }
}
