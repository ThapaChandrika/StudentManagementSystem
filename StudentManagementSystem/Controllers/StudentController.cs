using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repository;
using StudentManagementSystem.ViewModel;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult Index()
        {
            var students = _studentRepository.GetAllStudents();
            List<StudentViewModel> stdVmList = new List<StudentViewModel>();
            foreach (var item in students)
            {
                StudentViewModel stdVm = new StudentViewModel();
                stdVm.Id = item.Id;
                stdVm.Name = item.Name;
                stdVm.FatherName = item.FatherName;
                stdVm.Gender = item.Gender;
                stdVm.Address = item.Address;
                stdVm.Email = item.Email;
                stdVm.PhoneNo = item.PhoneNo;
                stdVm.DOB = item.DOB.Date;
                stdVm.ScholarshipType = item.Scholarship.Type;
                stdVm.FacultyName = item.Faculty.Name;
                stdVmList.Add(stdVm);
            }
            return View(stdVmList);
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
            }
            return RedirectToAction("Index");
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