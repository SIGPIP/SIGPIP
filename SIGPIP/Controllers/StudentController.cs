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

        [HttpPut]
        public IActionResult UpdateStudent(Guid studentId ,[FromBody] StudentModel student)
        {
            try
            {
                StudentModel studentModel = _databaseContext.Student.FirstOrDefault(student => student.studentId == studentId);

                if(studentModel != null)
                {
                    studentModel.studentId = studentId;
                    studentModel.studentNames = student.studentNames;
                    studentModel.studentLastNames = student.studentLastNames;
                    studentModel.studentCountry = student.studentCountry;
                    studentModel.studentCareer = student.studentCareer;
                    studentModel.studentBio = student.studentBio;
                    studentModel.studentSemester= student.studentSemester;

                    _databaseContext.Student.Update(studentModel);
                    _databaseContext.SaveChanges();
                    return Ok(studentModel);

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

    }
}
