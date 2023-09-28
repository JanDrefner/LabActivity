using LabActivity.Models;
using LabActivity.Services;
using Microsoft.AspNetCore.Mvc;

namespace Santos_IT_ELEC1C.Controllers
{
    public class InstructorController : Controller
    {
            private readonly IMyFakeDataService _dummyData;
            public InstructorController(IMyFakeDataService dummydata)
            {
                _dummyData = dummydata;
            }
            public IActionResult Index()
        {
            return View(_dummyData.InstructorList);
        }
        public IActionResult ShowDetail(int id)
        {
            //Search for the instructor whose id matches the given id
            Instructor? instructor = _dummyData.InstructorList.FirstOrDefault(inst => inst.Id == id);

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
            _dummyData.InstructorList.Add(newInstructor);
                return RedirectToAction("Index");
            }
        [HttpGet]
        public IActionResult UpdateInstructor(int id)
        {
            //Search for the instructor whose id matches the given id
            Instructor? instructor = _dummyData.InstructorList.FirstOrDefault(inst => inst.Id == id);

            if (instructor != null)//was an instructor found?
                return View(instructor);

            return NotFound();
        }
        [HttpPost]
        public IActionResult UpdateInstructor(Instructor instructorChanges)
        {
            Instructor? instructor = _dummyData.InstructorList.FirstOrDefault(inst => inst.Id == instructorChanges.Id);

            if (instructor != null) 
            { 
                instructor.FirstName = instructorChanges.FirstName;
                instructor.LastName = instructorChanges.LastName;
                instructor.InstructorRank = instructorChanges.InstructorRank;
                instructor.HiringDate = instructorChanges.HiringDate;
                instructor.IsTenured = instructorChanges.IsTenured;
            }
                return RedirectToAction("Index");
            }
        [HttpGet]
        public IActionResult DeleteInstructor(int id)
        {
            //Search for the instructor whose id matches the given id
            Instructor? instructor = _dummyData.InstructorList.FirstOrDefault(inst => inst.Id == id);

            if (instructor != null)//was an instructor found?
                return View(instructor);

            return NotFound();
        }
        [HttpPost]
        public IActionResult DeleteInstructor(Instructor newInstructor)
        {
            Instructor? instructor = _dummyData.InstructorList.FirstOrDefault(inst => inst.Id == newInstructor.Id);
            if (instructor != null)
                _dummyData.InstructorList.Remove(instructor);
                return RedirectToAction("Index");
        }
    }
}



