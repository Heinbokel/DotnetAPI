using DotnetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetAPI.Repositories.Configuration {

    public class DataContextEF: DbContext {

        private readonly IConfiguration _config;

        public DataContextEF(IConfiguration configuration) {
            this._config = configuration;
        }

        //We require a DbSet for each entity we want to use.
        public virtual DbSet<User> Users {get; set;}
        public virtual DbSet<UserSalary> UserSalaries {get; set;}
        public virtual DbSet<UserJob> UserJobs {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder 
                    .UseSqlServer(_config.GetConnectionString("DefaultConnection"), 
                    optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            }
        }

        //We need to tell EF where these DB Tables actually are.
        //We need to also map our names of our classes to our tables.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TutorialAppSchema");
            modelBuilder.Entity<User>()
                .ToTable("Users", "TutorialAppSchema")
                .HasKey(u => u.UserId);

            modelBuilder.Entity<UserSalary>()
                .ToTable("UserSalary", "TutorialAppSchema")
                .HasKey(u => u.UserId);

            modelBuilder.Entity<UserJob>()
                .ToTable("UserJobInfo", "TutorialAppSchema")
                .HasKey(u => u.UserId);
        }
    }

}