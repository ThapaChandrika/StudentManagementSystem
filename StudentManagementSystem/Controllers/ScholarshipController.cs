using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repository;

namespace StudentManagementSystem.Controllers
{
    public class ScholarshipController : Controller
    {
        private readonly IScholarshipRepository _scholarshipRepository;
        public ScholarshipController(IScholarshipRepository scholarshipRepository)
        {
            _scholarshipRepository = scholarshipRepository;
        }

        public IActionResult Index()
        {
            var model = _scholarshipRepository.GetAllScholarshipType();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Scholarship scholarship)
        {
            if (ModelState.IsValid)
            {
                Scholarship newScholarship = _scholarshipRepository.Add(scholarship);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(string id)
        {
            Scholarship scholarship = _scholarshipRepository.GetScholarshipType(id);
            return View(scholarship);
        }

        public IActionResult Delete(string id)
        {
            Scholarship scholarship = _scholarshipRepository.GetScholarshipType(id);
            return View(scholarship);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(string id)
        {
            Scholarship scholarship = _scholarshipRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(string id)
        {
            Scholarship scholarship = _scholarshipRepository.GetScholarshipType(id);
            return View(scholarship);
        }

        [HttpPost]
        public IActionResult Edit(Scholarship scholarshipChanges)
        {
            Scholarship scholarship = _scholarshipRepository.Update(scholarshipChanges);
            return RedirectToAction("Index");
        }

    }
}