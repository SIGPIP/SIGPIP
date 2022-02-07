using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGPIP.Context;
using SIGPIP.Models;

using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

using static System.Net.Mime.MediaTypeNames;

namespace SIGPIP.Controllers
{
    public class ProjectController : Controller
    {
        private readonly DatabaseContext _database;

        public ProjectController(DatabaseContext database)
        {
            this._database = database;
        }

        [HttpGet]
        public IActionResult GetStudentProjects(Guid studentId)
        {
            try
            {
                var studentProjects = _database.Project.Where(p => p.studentId == studentId);
                return Ok(studentProjects);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult RegisterStudentProject(ProjectModel projectModel)
        {
            if (String.IsNullOrWhiteSpace(projectModel.projectName) || String.IsNullOrWhiteSpace(projectModel.projectFramework) || String.IsNullOrWhiteSpace(projectModel.projectLanguages))
            {
                return BadRequest("Debes incluir el nombre, lenguaje y framework del proyecto");
            }

            try
            {
                var files = HttpContext.Request.Form.Files;

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        string imageId = Convert.ToString(Guid.NewGuid());
                        string fileExtension = Path.GetExtension(fileName);
                        string newFileName = imageId + fileExtension;

                        MemoryStream ms = new MemoryStream();
                        file.CopyTo(ms);

                        if(fileExtension == ".zip" || fileExtension == ".rar" || fileExtension == ".7zip")
                        {
                            projectModel.projectZipData = ms.ToArray();
                        }
                        else
                        {
                            projectModel.projectImageData = ms.ToArray();
                        }

                        ms.Close();
                        ms.Dispose();

                    }
                }

                if(projectModel.projectId == Guid.Empty)
                {
                    var existingProject = _database.Project.FirstOrDefault(p => p.projectName == projectModel.projectName);

                    if (existingProject != null)
                    {
                        return BadRequest("You already have a project with the same name");
                    }

                    existingProject = _database.Project.FirstOrDefault(p => p.projectLink == projectModel.projectLink);

                    if (existingProject != null)
                    {
                        return BadRequest("You already have a project with the same link");
                    }

                    existingProject = _database.Project.FirstOrDefault(p => p.projectRepoLink == projectModel.projectRepoLink);

                    if (existingProject != null)
                    {
                        return BadRequest("You already have a project with the same repository");
                    }

                    projectModel.projectId = Guid.NewGuid();
                    projectModel.projectUploadDate = DateTime.Now;
                    projectModel.projectLastUpdate = DateTime.Now;

                    _database.Project.Add(projectModel);
                    _database.SaveChanges();
                    return RedirectToAction("Home", "Student");
                }
                else
                {
                    UpdateStudentProject(projectModel);
                    return RedirectToAction("Home", "Student");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateStudentProject(ProjectModel projectModel)
        {
            try
            {
                var existentProject = _database.Project.FirstOrDefault(p => p.projectId == projectModel.projectId);

                if(existentProject != null)
                {
                    existentProject.projectName = projectModel.projectName;
                    existentProject.projectDescription = projectModel.projectDescription;
                    existentProject.projectRepoLink = projectModel.projectRepoLink;
                    existentProject.projectLink = projectModel.projectLink;
                    existentProject.projectFramework = projectModel.projectFramework;
                    existentProject.projectLanguages = projectModel.projectLanguages;
                    existentProject.projectLastUpdate = DateTime.Now;
                    if (projectModel.projectImageData != null)
                    {
                        existentProject.projectImageData = projectModel.projectImageData;
                    }
                    if(projectModel.projectZipData != null)
                    {
                        existentProject.projectZipData = projectModel.projectZipData;
                    }

                    _database.Project.Update(existentProject);
                    _database.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound("This project does not exists anymore");
                }
                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteStudentProject(string projectId)
        {
            var id = Guid.Parse(projectId);

            try
            {
                var existentProject = _database.Project.FirstOrDefault(p => p.projectId == id);

                if (existentProject != null)
                {
                    _database.Project.Remove(existentProject);
                    _database.SaveChanges();
                    return RedirectToAction("Home", "Student");
                }
                else
                {
                    return NotFound("This project does not exists anymore");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
