﻿using LabActivity.Models;
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
                HiringDate = DateTime.Now,
            },
            new Instructor()
            {
                Id = 2,
                FirstName = "Leo",
                LastName = "Lintag",
                IsTenured = false,
                InstructorRank = Rank.AssistantProfessor,
                HiringDate = DateTime.Now,
            },
            new Instructor()
            {
                Id = 3,
                FirstName = "Eugenia",
                LastName = "Zhuo",
                IsTenured = true,
                InstructorRank = Rank.AssociateProfessor,
                HiringDate = DateTime.Now,
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
    }

}

