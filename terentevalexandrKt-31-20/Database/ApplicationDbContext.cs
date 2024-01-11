using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using terentevalexandrKt_31_20.Database.Configurations;
using terentevalexandrKt_31_20.Models;

namespace terentevalexandrKt_31_20.Database
{
    public class ApplicationDbContext : DbContext
    {
        DbSet<EducationalSubject> EducationalSubjects { get; set; }
        DbSet<Professor> Professors { get; set; }
        DbSet<Workload> Workloads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EducationSubjectConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
            modelBuilder.ApplyConfiguration(new WorkloadConfiguration());
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
