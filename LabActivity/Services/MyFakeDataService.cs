using LabActivity.Models;
using LabActivity.Services;

namespace LabActivity.Services
{
    public class MyFakeDataService : IMyFakeDataService
    {
        public List<Student> StudentList { get; }
        public List<Instructor> InstructorList { get; }
        public MyFakeDataService() //constructor
        {
            StudentList = new List<Student>
            {
                new Student()
                {
                    Id= 1,FirstName = "Gabriel",LastName = "Montano", Course = Course.BSIT, AdmissionDate = DateTime.Parse("2022-08-26"), GPA = 2, Email = "ghaby021@gmail.com"
                },
                new Student()
                {
                    Id= 2,FirstName = "Zyx",LastName = "Montano", Course = Course.BSIS, AdmissionDate = DateTime.Parse("2022-08-07"), GPA = 1, Email = "zyx@gmail.com"
                },
                new Student()
                {
                    Id= 3,FirstName = "Aerdriel",LastName = "Montano", Course = Course.BSCS, AdmissionDate = DateTime.Parse("2020-01-25"), GPA = 1.5, Email = "aerdriel@gmail.com"
                }
            };

            InstructorList = new List<Instructor>()
            {
                new Instructor()
                {
                    Id = 1,
                    FirstName = "Gabriel",
                    LastName = "Montano",
                    IsTenured = true,
                    InstructorRank = Rank.Professor,
                    HiringDate = DateTime.Parse("09/05/2021")
                },
                new Instructor()
                {
                    Id = 2,
                    FirstName = "Leo",
                    LastName = "Lintag",
                    IsTenured = false,
                    InstructorRank = Rank.AssistantProfessor,
                    HiringDate = DateTime.Parse("01/11/2021")
                },
                new Instructor()
                {
                    Id = 3,
                    FirstName = "Eugenia",
                    LastName = "Zhuo",
                    IsTenured = true,
                    InstructorRank = Rank.AssociateProfessor,
                    HiringDate = DateTime.Now
                },
            };
        }
    }
}
