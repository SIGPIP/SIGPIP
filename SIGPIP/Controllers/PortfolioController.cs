using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SIGPIP.Context;
using SIGPIP.Models;

using System;

namespace SIGPIP.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public PortfolioController(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        [HttpGet]
        public IActionResult GetWorkExperience(Guid studentId)
        {
            try
            {
                var studentExperience = _databaseContext.Experience.Where(exp => exp.studentId == studentId).ToList();
                return Ok(studentExperience);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetSingleWorkExperience(int experienceId)
        {
            try
            {
                var studentExperience = _databaseContext.Experience.FirstOrDefault(exp => exp.experienceId == experienceId);
                return Ok(studentExperience);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddWorkExperience(ExperienceModel experience)
        {
            if (String.IsNullOrWhiteSpace(experience.experienceName) || String.IsNullOrWhiteSpace(experience.experienceEntity) ||
                String.IsNullOrWhiteSpace(experience.experiencePlace) || String.IsNullOrWhiteSpace(experience.experienceDescription))
            {
                return BadRequest("Los datos ingresados no son validos");
            }

            try
            {
                var existentExperience = _databaseContext.Experience.FirstOrDefault(exp => exp.experienceId == experience.experienceId);
                if (existentExperience != null)
                {
                    UpdateWorkExperience(experience);
                    return RedirectToAction("Portfolio", "Student");
                }
                _databaseContext.Add(experience);
                _databaseContext.SaveChanges();
                return RedirectToAction("Portfolio", "Student");
            }
            catch (Exception ex)
            {
                return BadRequest("Ha ocurrido un error, por favor intenta más tarde");
            }
        }

        [HttpPut]
        public IActionResult UpdateWorkExperience(ExperienceModel experience)
        {
            try
            {
                var existentExperience = _databaseContext.Experience.FirstOrDefault(exp => exp.experienceId == experience.experienceId);
                if (existentExperience != null)
                {
                    existentExperience.experienceName = experience.experienceName;
                    existentExperience.experiencePlace = experience.experiencePlace;
                    existentExperience.experienceEntity = experience.experienceEntity;
                    existentExperience.experienceDescription = experience.experienceDescription;
                    existentExperience.experienceStartDate = experience.experienceStartDate;
                    existentExperience.experienceEndDate = experience.experienceEndDate;

                    _databaseContext.Experience.Update(existentExperience);
                    _databaseContext.SaveChanges();

                    return RedirectToAction("Portfolio", "Student");
                }
                else
                {
                    return BadRequest("This experience does not exists and cannot be updated");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]

        public IActionResult DeleteWorkExperience(int experienceId)
        {
            try
            {
                var experience = _databaseContext.Experience.FirstOrDefault(exp => exp.experienceId == experienceId);
                if(experience != null)
                {
                    _databaseContext.Remove(experience);
                    _databaseContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("This experience has been removed already");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public ActionResult ViewPortfolio()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }
    }
}
