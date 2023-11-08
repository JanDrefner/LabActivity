using LabActivity.Data;
using LabActivity.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabActivity.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _dbData;
        public StudentController(AppDbContext dbData)
        {
            _dbData = dbData;
        }
        public IActionResult Index()
        {
            return View(_dbData.Students);
        }
        public IActionResult ShowDetail(int id)
        {
            //Search for the instructor whose id matches the given id
            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an instructor found?
                return View(student);

            return NotFound();
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student newStudent)
        {
            if (!ModelState.IsValid)
            {
                return View();
                _dbData.Students.Add(newStudent);
                return RedirectToAction("Index");
            }
            _dbData.Students.Add(newStudent);
            _dbData.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {   
            //Search for the instructor whose id matches the given id
            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an instructor found?
                return View(student);

            return NotFound();
        }
        [HttpPost]
        public IActionResult UpdateStudent(Student studentChanges)
        {
            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == studentChanges.Id);

            if (student != null)
            {
                student.FirstName = studentChanges.FirstName;
                student.LastName = studentChanges.LastName;
                student.Email = studentChanges.Email;
                student.AdmissionDate = studentChanges.AdmissionDate;
                student.GPA = studentChanges.GPA;
                student.Course = studentChanges.Course;
                _dbData.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            //Search for the instructor whose id matches the given id
            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == id);

            if (student != null)//was an instructor found?
                return View(student);

            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteStudent(Student newStudent)

        {
            //Search for the instructor whose id matches the given id
            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == newStudent.Id);

            if (student != null)//was an instructor found?
                _dbData.Students.Remove(student);
            _dbData.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
