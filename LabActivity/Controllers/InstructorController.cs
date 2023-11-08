using LabActivity.Data;
using LabActivity.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabActivity.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDbContext _dbData;
        public InstructorController(AppDbContext dbData)
        {
            _dbData = dbData;
        }
        public IActionResult Index()
        {
            return View(_dbData.Instructors);
        }
        public IActionResult ShowDetail(int id)
        {
            //Search for the instructor whose id matches the given id
            Instructor? instructor = _dbData.Instructors.FirstOrDefault(ins => ins.Id == id);

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
            if (!ModelState.IsValid)
            {
                return View();
                _dbData.Instructors.Add(newInstructor);
                return RedirectToAction("Index");
            }
            _dbData.Instructors.Add(newInstructor);
            _dbData.SaveChanges();
            return RedirectToAction("Index");
            }
        [HttpGet]
        public IActionResult UpdateInstructor(int id)
        {
            //Search for the instructor whose id matches the given id
            Instructor? instructor = _dbData.Instructors.FirstOrDefault(ins => ins.Id == id);

            if (instructor != null)//was an instructor found?
                return View(instructor);

            return NotFound();
        }
        [HttpPost]
        public IActionResult UpdateInstructor(Instructor instructorChanges)
        {
            Instructor? instructor = _dbData.Instructors.FirstOrDefault(ins => ins.Id == instructorChanges.Id);

            if (instructor != null) 
            { 
                instructor.FirstName = instructorChanges.FirstName;
                instructor.LastName = instructorChanges.LastName;
                instructor.InstructorRank = instructorChanges.InstructorRank;
                instructor.HiringDate = instructorChanges.HiringDate;
                instructor.IsTenured = instructorChanges.IsTenured;
                _dbData.SaveChanges();
            }
                return RedirectToAction("Index");
            }
        [HttpGet]
        public IActionResult DeleteInstructor(int id)
        {
            //Search for the instructor whose id matches the given id
            Instructor? instructor = _dbData.Instructors.FirstOrDefault(ins => ins.Id == id);

            if (instructor != null)//was an instructor found?
                return View(instructor);

            return NotFound();
        }
        [HttpPost]
        public IActionResult DeleteInstructor(Instructor newInstructor)
        {
            Instructor? instructor = _dbData.Instructors.FirstOrDefault(ins => ins.Id == newInstructor.Id);
            if (instructor != null)
                _dbData.Instructors.Remove(instructor);
            _dbData.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}



