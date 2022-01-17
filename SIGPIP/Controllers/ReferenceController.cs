using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGPIP.Context;
using SIGPIP.Models;
using System;
using System.Linq;

namespace SIGPIP.Controllers
{
    public class ReferenceController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public ReferenceController(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        [HttpGet]
        public IActionResult GetReference()
        {
            try
            {
                var list = _databaseContext.Reference;
                return View(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddReference(ReferenceModel reference)
        {
            ReferenceModel referenceModel1 = _databaseContext.Reference.FirstOrDefault(reference1 => reference1.referenceId == reference.referenceId);
            if (referenceModel1 == null)
            {
                try
                {
                    Guid _referenceId = Guid.NewGuid();
                    ReferenceModel referenceModel = new ReferenceModel()
                    {
                        referenceId = _referenceId,
                        studentId = reference.studentId,
                        referenceName = reference.referenceName,
                        referenceAgent = reference.referenceAgent,
                        referencePhone = reference.referencePhone,
                        referenceCompany = reference.referenceCompany
                    };
                    _databaseContext.Reference.Add(referenceModel);
                    _databaseContext.SaveChanges();
                    TempData["successReferenceAdd"] = "Reference added successfully!";
                }
                catch (Exception ex)
                {
                    TempData["errorReferenceAdd"] = ex;
                }
                return RedirectToAction("Portfolio", "Student");
            }
            else
            {
                return UpdateReference(reference.referenceId, reference);
            }           
        }

        [HttpPost]
        public IActionResult UpdateReference(Guid referenceId, ReferenceModel reference1)
        {
            ReferenceModel referenceModel = _databaseContext.Reference.FirstOrDefault(reference => reference.referenceId == referenceId);
            if (referenceModel != null)
            {
                try
                {
                    referenceModel.referenceName = reference1.referenceName;
                    referenceModel.referenceAgent = reference1.referenceAgent;
                    referenceModel.referencePhone = reference1.referencePhone;
                    referenceModel.referenceCompany = reference1.referenceCompany;
                    _databaseContext.Reference.Update(referenceModel);
                    _databaseContext.SaveChanges();
                    TempData["successUpdatingReference"] = "Reference updated successfully!";
                }
                catch (Exception ex)
                {
                    TempData["errorUpdatingReference"] = ex;
                }
            }
            else
            {
                TempData["errorUpdatingReference"] = "Reference could not be updated";
            }
            return RedirectToAction("Portfolio", "Student");
        }
        [HttpGet]
        public IActionResult DeleteReference(Guid referenceId)
        {
            try
            {
                ReferenceModel referenceModel = _databaseContext.Reference.FirstOrDefault(reference => reference.referenceId == referenceId);
                if (referenceModel != null)
                {
                    _databaseContext.Reference.Remove(referenceModel);
                    _databaseContext.SaveChanges();
                    TempData["successDeletingReference"] = "Reference deleted successfully!";
                }
                else
                {
                    TempData["errorDeletingReference"] = "Reference could not be deleted";
                }
            }
            catch (Exception ex)
            {
                TempData["errorDeletingReference"] = ex;
            }
            return RedirectToAction("Portfolio", "Student");
        }
    }
}
