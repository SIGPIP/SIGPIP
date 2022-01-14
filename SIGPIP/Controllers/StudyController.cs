using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGPIP.Context;
using SIGPIP.Models;
using System;
using System.Linq;

namespace SIGPIP.Controllers
{
    public class StudyController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public StudyController(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        [HttpPost]
        public IActionResult AddStudy(StudyModel study)
        {
            StudyModel studyModel1 = _databaseContext.Study.FirstOrDefault(study1 => study1.studyId == study.studyId);
            if (studyModel1 == null) 
            { 
                try
                {
                    Guid _studyId = Guid.NewGuid();
                    StudyModel studyModel = new StudyModel()
                    {
                        studyId = _studyId,
                        studentId =study.studentId,
                        studyYear = study.studyYear,
                        studyGrade = study.studyGrade,
                        studyName = study.studyName,
                        studyPlace = study.studyPlace,
                        studyCity = study.studyCity,
                        studyCountry = study.studyCountry
                    };
                    _databaseContext.Study.Add(studyModel);
                    _databaseContext.SaveChanges();
                    TempData["successStudyAdd"] = "Study added successfully!";
                    return RedirectToAction("Portfolio","Student");
                }
                catch (Exception ex)
                {
                    TempData["errorStudyAdd"] = ex;
                }
                return RedirectToAction("Portfolio","Student");
            }
            else
            {
                return UpdateStudy(study.studyId, study);
            }
        }

        [HttpGet]
        public IActionResult GetStudy()
        {
            try
            {
                var list = _databaseContext.Study;
                return View(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult UpdateStudy(Guid studyId)
        {
            if (studyId == null)
            {
                return (NotFound());
            }
            var study = _databaseContext.Study.Find(studyId);
            if (study == null)
            {
                return NotFound();
            }

            return View(study);
        }

        [HttpPost]
        public IActionResult UpdateStudy(Guid studyId, StudyModel study1)
        {
            StudyModel studyModel = _databaseContext.Study.FirstOrDefault(study => study.studyId == studyId);
            if (studyModel != null)
            {
                try
                {
                    studyModel.studyYear = study1.studyYear;
                    studyModel.studyGrade = study1.studyGrade;
                    studyModel.studyName = study1.studyName;
                    studyModel.studyPlace = study1.studyPlace;
                    studyModel.studyCity = study1.studyCity;
                    studyModel.studyCountry = study1.studyCountry;
                    _databaseContext.Study.Update(studyModel);
                    _databaseContext.SaveChanges();
                    TempData["successUpdatingStudy"] = "Study updated successfully!";
                }
                catch (Exception ex)
                {
                    TempData["errorUpdatingStudy"] = ex;
                }
            }
            else
            {
                TempData["errorUpdatingStudy"] = "Study could not be updated";
            }
            return RedirectToAction("Portfolio","Student");
        }
        [HttpGet]
        public IActionResult DeleteStudy(Guid studyId)
        {
            try
            {
                StudyModel studyModel = _databaseContext.Study.FirstOrDefault(study => study.studyId == studyId);

                if (studyModel != null)
                {
                    _databaseContext.Study.Remove(studyModel);
                    _databaseContext.SaveChanges();
                    TempData["successDeletingStudy"] = "Study updated successfully!";
                }
                else
                {
                    TempData["errorDeletingStudy"] = "Study could not be deleted";
                }
            }
            catch (Exception ex)
            {
                TempData["errorDeletingStudy"] = ex;
            }
            return RedirectToAction("Portfolio", "Student");
        }
    }
}
