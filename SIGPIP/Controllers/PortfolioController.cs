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

                    return Ok();
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
                    _databaseContext.Experience.Remove(experience);
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

        [HttpGet]
        public IActionResult GetHabilities(Guid studentId)
        {
            try
            {
                var studentHabilities = _databaseContext.Hability.Where(hab => hab.studentId == studentId).ToList();
                return Ok(studentHabilities);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetSingleHability(int habilityId)
        {
            try
            {
                var studentHability = _databaseContext.Hability.FirstOrDefault(hab => hab.habilityId == habilityId);
                return Ok(studentHability);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddHability(HabilityModel hability)
        {
            try
            {
                var existentHability = _databaseContext.Hability.FirstOrDefault(hab => hab.habilityId == hability.habilityId);

                if(existentHability != null)
                {
                    UpdateHability(hability);
                    return RedirectToAction("Portfolio", "Student");
                }
                _databaseContext.Hability.Add(hability);
                _databaseContext.SaveChanges();
                return RedirectToAction("Portfolio", "Student");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateHability(HabilityModel hability)
        {
            try
            {
                var existentHability = _databaseContext.Hability.FirstOrDefault(hab => hab.habilityId == hability.habilityId);

                if(existentHability != null)
                {
                    existentHability.habilityName = hability.habilityName;
                    _databaseContext.Hability.Update(existentHability);
                    _databaseContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("This language or framework doesn´t exists anymore");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult deleteHability(int habilityId)
        {
            try
            {
                var hability = _databaseContext.Hability.FirstOrDefault(hab => hab.habilityId == habilityId);
                if (hability != null)
                {
                    _databaseContext.Hability.Remove(hability);
                    _databaseContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("This experience has been removed already");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetInterests(Guid studentId)
        {
            try
            {
                var studentInterests = _databaseContext.Interest.Where(its => its.studentId == studentId).ToList();
                return Ok(studentInterests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetSingleInterest(int interestId)
        {
            try
            {
                var studentInterest = _databaseContext.Interest.FirstOrDefault(its => its.interestId == interestId);
                return Ok(studentInterest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddInterest(InterestModel interest)
        {
            try
            {
                var existentInterest = _databaseContext.Interest.FirstOrDefault(its => its.interestId == interest.interestId);

                if (existentInterest != null)
                {
                    UpdateInterest(interest);
                    return RedirectToAction("Portfolio", "Student");
                }

                _databaseContext.Interest.Add(interest);
                _databaseContext.SaveChanges();
                return RedirectToAction("Portfolio", "Student");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateInterest(InterestModel interest)
        {
            try
            {
                var existentInterest = _databaseContext.Interest.FirstOrDefault(ist => ist.interestId == interest.interestId);

                if (existentInterest != null)
                {
                    existentInterest.interestName = interest.interestName;
                    _databaseContext.Interest.Update(existentInterest);
                    _databaseContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("This language or framework doesn´t exists anymore");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult deleteInterest(int interestId)
        {
            try
            {
                var interest = _databaseContext.Interest.FirstOrDefault(ist => ist.interestId == interestId);
                if (interest != null)
                {
                    _databaseContext.Interest.Remove(interest);
                    _databaseContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("This experience has been removed already");
                }
            }
            catch (Exception ex)
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
