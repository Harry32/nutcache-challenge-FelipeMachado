using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration configuration;

        public DataContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(configuration.GetConnectionString("EmployeeDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Team>().ToTable("Team");
        }
    }
}