using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIGPIP.Context;
using SIGPIP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGPIP.Controllers
{
    public class StudentController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public StudentController(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        public bool LoggedInVerify()
        {
           return (HttpContext.Session.GetString("loggedIn") == null ? false : true);
        }

        public IActionResult Home()
        {
            if (LoggedInVerify() == false)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.studentName = HttpContext.Session.GetString("studentName");
                ViewBag.studentIdLogged = HttpContext.Session.GetString("studentIdLogged");
                ViewBag.studentEmail = HttpContext.Session.GetString("studentEmail");
                return View();
            }
        }

        public IActionResult Privacy()
        {
            if (LoggedInVerify() == false)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        /*Login Method Here*/
        [HttpPost]
        public IActionResult Login(StudentModel students)
        {
            string studentsHashPass = Encryption.EnryptString(students.studentPassword);
            var studentLoggedIn = _databaseContext.Student.SingleOrDefault(std => std.studentEmail == students.studentEmail &&  std.studentPassword == studentsHashPass);
            if (studentLoggedIn != null)
            {
                HttpContext.Session.SetString("studentIdLogged", studentLoggedIn.studentId.ToString());
                HttpContext.Session.SetString("studentName", studentLoggedIn.studentNames);
                HttpContext.Session.SetString("studentLastName", studentLoggedIn.studentLastNames);
                HttpContext.Session.SetString("studentCountry", studentLoggedIn.studentCountry);
                HttpContext.Session.SetString("studentCareer", studentLoggedIn.studentCareer);
                HttpContext.Session.SetString("studentSemester", studentLoggedIn.studentSemester.ToString());
                HttpContext.Session.SetString("studentEmail", studentLoggedIn.studentEmail);
                if(studentLoggedIn.studentBio != null)
                {
                    HttpContext.Session.SetString("studentBio", studentLoggedIn.studentBio);
                }
                else
                {
                    HttpContext.Session.SetString("studentBio", "");
                }
                HttpContext.Session.SetString("loggedIn", "logged");
                return RedirectToAction("Home");
            }
            else
            {
                TempData["errorLogin"] = "This user does not exist or check the information";
                return View();
            }
        }

        public bool EmailExistenceValidation(string emailStudent)
        {
            var existenceEmail = _databaseContext.Student.SingleOrDefault(std => std.studentEmail == emailStudent);
            return existenceEmail == null ? false : true;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(StudentModel student)
        {
            string pass = student.studentPassword;
            string cpass = student.studentConfirmPassword;

            if (ModelState.IsValid)
            {
                if (pass == cpass)
                {
                    if (EmailExistenceValidation(student.studentEmail) == true)
                    {
                        TempData["emailExists"] = "Email already exists!";
                    }
                    else
                    {
                        try
                        {
                            Guid _studentId = Guid.NewGuid();
                            string hashPass = Encryption.EnryptString(pass);

                            StudentModel studentModel = new StudentModel()
                            {
                                studentId = _studentId,
                                studentNames = student.studentNames,
                                studentLastNames = student.studentLastNames,
                                studentBio = student.studentBio,
                                studentCareer = student.studentCareer,
                                studentCountry = student.studentCountry,
                                studentEmail = student.studentEmail,
                                studentPassword = hashPass,
                                studentConfirmPassword = hashPass,
                                studentSemester = student.studentSemester
                            };
                            HttpContext.Session.SetString("nowStudentId", studentModel.studentId.ToString());
                            _databaseContext.Student.Add(studentModel);
                            _databaseContext.SaveChanges();
                            TempData["successRegister"] = "Account created successfully!";
                            return RedirectToAction("Login", studentModel);
                        }
                        catch (Exception ex)
                        {
                            TempData["errorRegister"] = ex;
                        }
                    }
                    
                }
            }
            else
            {
                TempData["errorRegister"] = "Account could not be created";
            }
            return View();
        }

        [HttpGet]
        public IActionResult GetStudent()
        {
            try
            {
                var students = _databaseContext.Student.ToList();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IActionResult UpdateStudent(Guid studentId)
        {
            if(studentId == null)
            {
                return (NotFound());
            }
            var student = _databaseContext.Student.Find(studentId);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult UpdateStudent(Guid studentId, StudentModel student1)
        {
                StudentModel studentModel = _databaseContext.Student.FirstOrDefault(student => student.studentId == studentId);
                if (studentModel!=null){
                    try
                    {
                        studentModel.studentNames = student1.studentNames;
                        studentModel.studentLastNames = student1.studentLastNames;
                        studentModel.studentCountry = student1.studentCountry;
                        studentModel.studentCareer = student1.studentCareer;
                        studentModel.studentBio = student1.studentBio;
                        studentModel.studentSemester = student1.studentSemester;
                        _databaseContext.Student.Update(studentModel);
                        _databaseContext.SaveChanges();
                        HttpContext.Session.SetString("studentIdLogged", studentModel.studentId.ToString());
                        HttpContext.Session.SetString("studentName", studentModel.studentNames);
                        HttpContext.Session.SetString("studentLastName", studentModel.studentLastNames);
                        HttpContext.Session.SetString("studentCountry", studentModel.studentCountry);
                        HttpContext.Session.SetString("studentCareer", studentModel.studentCareer);
                        HttpContext.Session.SetString("studentSemester", studentModel.studentSemester.ToString());
                        HttpContext.Session.SetString("studentEmail", studentModel.studentEmail);
                        if (studentModel.studentBio != null)
                        {
                            HttpContext.Session.SetString("studentBio", studentModel.studentBio);
                        }
                        else
                        {
                            HttpContext.Session.SetString("studentBio", "");
                        }
                        HttpContext.Session.SetString("loggedIn", "logged");
                        TempData["successUpdate"] = "Personal Information updated successfully!";
                    }
                catch (Exception ex)
                {
                    TempData["errorUpdating"] = ex;
                }
            }
            else
            {
                TempData["errorUpdating"] = "Personal Information could not be updated";
            }
            return RedirectToAction("Portfolio");
        }

        [HttpDelete]
        public IActionResult DeleteStudent(Guid studentId)
        {
            try
            {
                StudentModel studentModel = _databaseContext.Student.FirstOrDefault(student => student.studentId == studentId);

                if (studentModel != null)
                {
                    _databaseContext.Student.Remove(studentModel);
                    _databaseContext.SaveChanges();
                    return Ok("Eliminado");
                }
                else
                {
                    return NotFound("Estudiante no encontrado");

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Portfolio()
        {
            if (LoggedInVerify() == false)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.studentName = HttpContext.Session.GetString("studentName");
                ViewBag.studentIdLogged = HttpContext.Session.GetString("studentIdLogged");
                ViewBag.studentLastName = HttpContext.Session.GetString("studentLastName");
                ViewBag.studentCountry = HttpContext.Session.GetString("studentCountry");
                ViewBag.studentCareer = HttpContext.Session.GetString("studentCareer");
                ViewBag.studentSemester = HttpContext.Session.GetString("studentSemester");
                ViewBag.studentEmail = HttpContext.Session.GetString("studentEmail");
                ViewBag.studentBio = HttpContext.Session.GetString("studentBio");
                return View();
            }
        }

    }
}
