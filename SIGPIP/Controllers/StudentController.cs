using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIGPIP.Context;
using SIGPIP.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        [HttpPost]
        public IActionResult RegisterStudent([FromBody] StudentModel student)
        {
            try
            {
                Guid _studentId = Guid.NewGuid();

                StudentModel studentModel = new StudentModel()
                {
                    studentId = _studentId,
                    studentNames = student.studentNames,
                    studentLastNames = student.studentLastNames,
                    studentBio = student.studentBio,
                    studentCareer = student.studentCareer,
                    studentCountry = student.studentCountry,
                    studentEmail = student.studentEmail,
                    studentSemester = student.studentSemester
                };

                _databaseContext.Student.Add(studentModel);
                _databaseContext.SaveChanges();
                return Ok(studentModel);
            }
            catch(Exception ex)
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
        public IActionResult Portfolio()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
