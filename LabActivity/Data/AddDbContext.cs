using LabActivity.Models;
using Microsoft.EntityFrameworkCore;
namespace LabActivity.Data;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Instructor> Instructors { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    FirstName = "Gabriel",
                    LastName = "Montano",
                    Course = Course.BSIT,
                    AdmissionDate = DateTime.Parse("2022-08-26"),
                    GPA = 2,
                    Email = "ghaby021@gmail.com",
                    PhoneNumber = "0912-232-1235"
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Zyx",
                    LastName = "Montano",
                    Course = Course.BSIS,
                    AdmissionDate = DateTime.Parse("2022-08-07"),
                    GPA = 1,
                    Email = "zyx@gmail.com",
                    PhoneNumber = "0912-222-1634"
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "Aerdriel",
                    LastName = "Montano",
                    Course = Course.BSCS,
                    AdmissionDate = DateTime.Parse("2020-01-25"),
                    GPA = 1.5,
                    Email = "aerdriel@gmail.com",
                    PhoneNumber = "0922-182-4535"
                }
            );
             

        modelBuilder.Entity<Instructor>().HasData(
            new Instructor()
            {
                Id = 100,
                FirstName = "Gabriel",
                LastName = "Montano",
                IsTenured = false,
                HiringDate = DateTime.Parse("2018-08-05"),
                InstructorRank = Rank.AssistantProfessor,
                PhoneNumber = "0912-345-6789"
            },
            new Instructor()
            {
                Id = 200,
                FirstName = "Leo",
                LastName = "Lintag",
                IsTenured = true,
                HiringDate = DateTime.Parse("2018-08-05"),
                InstructorRank = Rank.Professor,
                PhoneNumber = "0911-234-5789"
            }
            );
    }
}
