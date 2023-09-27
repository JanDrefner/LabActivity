using LabActivity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Santos_IT_ELEC1C.Controllers
{
    public class InstructorController : Controller
    {

        public List<Instructor> InstructorList = new List<Instructor>()
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

        public IActionResult Index()
        {
            return View(InstructorList);
        }
        public IActionResult ShowDetail(int id)
        {
            //Search for the instructor whose id matches the given id
            Instructor? instructor = InstructorList.FirstOrDefault(inst => inst.Id == id);

            if (instructor != null)//was an instructor found?
                return View(instructor);

            return NotFound();
        }

        [HttpGet]
        public IActionResult AddInstructor()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddInstructor(Instructor newInstructor)
        {
            InstructorList.Add(newInstructor);
            return View("Index", InstructorList);
        }
        [HttpGet]
        public IActionResult UpdateInstructor(int id)
        {
            //Search for the instructor whose id matches the given id
            Instructor? instructor = InstructorList.FirstOrDefault(inst => inst.Id == id);

            if (instructor != null)//was an instructor found?
                return View(instructor);

            return NotFound();
        }
        [HttpPost]
        public IActionResult UpdateInstructor(Instructor instructorChanges)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(inst => inst.Id == instructorChanges.Id);

            if (instructor != null) 
            { 
                instructor.FirstName = instructorChanges.FirstName;
                instructor.LastName = instructorChanges.LastName;
                instructor.InstructorRank = instructorChanges.InstructorRank;
                instructor.HiringDate = instructorChanges.HiringDate;
                instructor.IsTenured = instructorChanges.IsTenured;
            }
                return View("Index", InstructorList);
        }
        [HttpGet]
        public IActionResult DeleteInstructor(int id)
        {
            //Search for the instructor whose id matches the given id
            Instructor? instructor = InstructorList.FirstOrDefault(inst => inst.Id == id);

            if (instructor != null)//was an instructor found?
                return View(instructor);

            return NotFound();
        }
        [HttpPost]
        public IActionResult DeleteInstructor(Instructor newInstructor)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(inst => inst.Id == newInstructor.Id);
            if (instructor != null)
                InstructorList.Remove(instructor);
            return View("Index", InstructorList);
        }
    }
}



