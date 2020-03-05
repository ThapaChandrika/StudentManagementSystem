using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IFacultyRepository _facultyRepository;
        public FacultyController(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }

        public IActionResult Index()
        {
            var model = _facultyRepository.GetAllFaculties();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                Faculty newFaculty = _facultyRepository.Add(faculty);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Faculty faculty = _facultyRepository.GetFaculty(id);
            return View(faculty);
        }

        public IActionResult Delete(int id)
        {
            Faculty faculty = _facultyRepository.GetFaculty(id);
            return View(faculty);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            Faculty faculty = _facultyRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Faculty faculty = _facultyRepository.GetFaculty(id);
            return View(faculty);
        }

        [HttpPost]
        public IActionResult Edit(Faculty facultyChanges)
        {
            Faculty faculty = _facultyRepository.Update(facultyChanges);
            return RedirectToAction("Index");
        }

    }
}