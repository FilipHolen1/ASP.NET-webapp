using Microsoft.EntityFrameworkCore;
using SchoolTracker.Model;


namespace SchoolTracker.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> Students{ get; set; }
        public DbSet<Profesor> Profesors { get; set; }
        public DbSet<ClassYear> ClassYears { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Grade>()
                .HasKey(g => new { g.StudentID, g.SubjectID });

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentID);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Subject)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.SubjectID);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.ClassYear)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassYearID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subject>()
                .HasOne(s => s.Profesor)
                .WithMany(p => p.Subjects)
                .HasForeignKey(s => s.ProfesorID)
                .OnDelete(DeleteBehavior.Restrict);

         

        }

    }

}
