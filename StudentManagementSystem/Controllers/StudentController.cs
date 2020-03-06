using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repository;
using StudentManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IScholarshipRepository _scholarshipRepository;

        public StudentController(IStudentRepository studentRepository, IFacultyRepository facultyRepository,
           IScholarshipRepository scholarshipRepository)
        {
            _studentRepository = studentRepository;
            _facultyRepository = facultyRepository;
            _scholarshipRepository = scholarshipRepository;
        }

        public async Task<IActionResult> Index(string searchString, string currentFilter, int? pageNumber)
        {

            var students = _studentRepository
                .AsNoTrackingTable()
                .Select(x => new StudentViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    FatherName = x.FatherName,
                    Gender = x.Gender,
                    Address = x.Address,
                    Email = x.Email,
                    PhoneNo = x.PhoneNo,
                    DOB = x.DOB.Date,
                    ScholarshipType = x.Scholarship.Type,
                    FacultyName = x.Faculty.Name
                });
                       
            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Name.Contains(searchString));
            }

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            int pageSize = 3;
            //return View(stdVmList.OrderBy(x => x.Name));
            return View(await PaginatedList<StudentViewModel>.CreateAsync(students, pageNumber ?? 1, pageSize));
        }

        public IActionResult Create()
        {
            var facultyList = _facultyRepository.GetAllFaculties().ToList();
            facultyList.Insert(0, new Faculty { Id = 0, Name = "Select" });

            var scholarshipList = _scholarshipRepository.GetAllScholarshipType().ToList();
            scholarshipList.Insert(0, new Scholarship { Id = "0", Type = "Select" });

            ViewBag.facultyList = facultyList;
            ViewBag.scholarshipList = scholarshipList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel studentVm)
        {
            var facultyList = _facultyRepository.GetAllFaculties().ToList();
            facultyList.Insert(0, new Faculty { Id = 0, Name = "Select" });

            var scholarshipList = _scholarshipRepository.GetAllScholarshipType().ToList();
            scholarshipList.Insert(0, new Scholarship { Id = "0", Type = "Select" });

            ViewBag.facultyList = facultyList;
            ViewBag.scholarshipList = scholarshipList;
            if (ModelState.IsValid)
            {
                Student student = new Student
                {
                    Name = studentVm.Name,
                    FatherName = studentVm.FatherName,
                    Gender = studentVm.Gender,
                    Address = studentVm.Address,
                    Email = studentVm.Email,
                    PhoneNo = studentVm.PhoneNo,
                    DOB = studentVm.DOB,
                    ScholarshipId = studentVm.ScholarshipId.ToString(),
                    FacultyId = studentVm.FacultyId
                };
                Student newStudent = _studentRepository.Add(student);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            Student student = _studentRepository.GetStudent(id);
            StudentViewModel stdVm = new StudentViewModel
            {
                Id = student.Id,
                Name = student.Name,
                FatherName = student.FatherName,
                Gender = student.Gender,
                Address = student.Address,
                Email = student.Email,
                PhoneNo = student.PhoneNo,
                DOB = student.DOB,
                ScholarshipType = student.Scholarship.Type,
                FacultyName = student.Faculty.Name
            };
            return View(stdVm);
        }

        public IActionResult Delete(int id)
        {
            Student student = _studentRepository.GetStudent(id);
            StudentViewModel stdVm = new StudentViewModel
            {
                Id = student.Id,
                Name = student.Name,
                FatherName = student.FatherName,
                Gender = student.Gender,
                Address = student.Address,
                Email = student.Email,
                PhoneNo = student.PhoneNo,
                DOB = student.DOB,
                ScholarshipType = student.Scholarship.Type,
                FacultyName = student.Faculty.Name
            };
            return View(stdVm);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            Student student = _studentRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var facultyList = _facultyRepository.GetAllFaculties().ToList();
            //facultyList.Insert(0, new Faculty { Id = 0, Name = "Select" });

            var scholarshipList = _scholarshipRepository.GetAllScholarshipType().ToList();
            //billingList.Insert(0, new Billing { Id = 0, Type = "Select" });

            ViewBag.facultyList = facultyList;
            ViewBag.scholarshipList = scholarshipList;

            Student student = _studentRepository.GetStudent(id);
            StudentViewModel stdVm = new StudentViewModel
            {
                Id = student.Id,
                Name = student.Name,
                FatherName = student.FatherName,
                Gender = student.Gender,
                Address = student.Address,
                Email = student.Email,
                PhoneNo = student.PhoneNo,
                DOB = student.DOB,
                ScholarshipType = student.Scholarship.Type,
                FacultyName = student.Faculty.Name
            };
            return View(stdVm);
        }

        [HttpPost]
        public IActionResult Edit(StudentViewModel studentChanges)
        {
            Student stdUpdate = new Student
            {
                Id = studentChanges.Id,
                Name = studentChanges.Name,
                FatherName = studentChanges.FatherName,
                Gender = studentChanges.Gender,
                Address = studentChanges.Address,
                Email = studentChanges.Email,
                PhoneNo = studentChanges.PhoneNo,
                DOB = studentChanges.DOB,
                ScholarshipId = studentChanges.ScholarshipId.ToString(),
                FacultyId = studentChanges.FacultyId
            };
            Student student = _studentRepository.Update(stdUpdate);
            return RedirectToAction("Index");
        }
    }
}