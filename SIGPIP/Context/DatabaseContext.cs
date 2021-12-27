using Microsoft.EntityFrameworkCore;
using SIGPIP.Models;

namespace SIGPIP.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> option) : base(option)
        {

        }

        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<ExperienceModel> Experience { get; set; }
        public DbSet<HabilityModel> Hability { get; set; }
        public DbSet<InterestModel> Interest { get; set; }
        public DbSet<PendingProjectModel> PendingProject { get; set; }
        public DbSet<ProjectModel> Project { get; set; }
        public DbSet<ReferenceModel> Reference { get; set; }
        public DbSet<StudentModel> Student { get; set; }
        public DbSet<StudyModel> Study { get; set; }
        public DbSet<UniversityModel> University { get; set; }


    }
}
