using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SIGPIP.Context;
using SIGPIP.Controllers;
using SIGPIP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SIGPIP_Tests
{
    
    [TestClass]
    public class StudentControllerTests
    {
        public static class GetContext
        {
            private static IConfigurationRoot _configuration;
            public static async Task<DatabaseContext> GetDatabaseContextAsync()
            {
                var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json");

                _configuration = builder.Build();
                var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer(_configuration.GetConnectionString("SQLServerConnection")).Options;
                var databaseContext = new DatabaseContext(options);
                databaseContext.Database.EnsureCreated();
                /*
                if (await databaseContext.Student.CountAsync() <= 0)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        databaseContext.Student.Add(new StudentModel()
                        {
                            studentId = Guid.NewGuid(),
                            studentNames = "Test",
                            studentLastNames = "Context",
                            studentPassword = "123456789",
                            studentConfirmPassword = "123456789",
                            studentEmail = "context@admin.com",
                            studentCountry = "Colombia",
                            studentSemester = 5,
                            studentCareer = "Sistemas",
                            studentBio = "Context Test"
                        });
                        await databaseContext.SaveChangesAsync();
                    }
                }
                */
                return databaseContext;
            }

        }
        

        // EMAIL - PLACEHOLDER
        [TestMethod]
        //Validation Empty.
        public void CP_logPH1_empty()
        {
            StudentModel model = new StudentModel { studentEmail = "" };

            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentEmail")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "Email required"));
        }
        [TestMethod]
        //Valdiation Incorrect.
        public void CP_logPH1_incorrect()
        {
            StudentModel model = new StudentModel { studentEmail = "juanma@s" };

            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentEmail")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "The Email field is not a valid e-mail address"));
        }
        [TestMethod]
        //Valdiarion Correct.
        public void CP_logPH1_correct()
        {
            StudentModel model = new StudentModel { studentEmail = "luis@gmail.com" };

            var result = ValidateModel(model);

            Assert.IsFalse(result.Any(x => x.MemberNames.Contains("studentEmail")));
        }


        // PASSWORD - PLACEHOLDER
        [TestMethod]
        //Validation White Spaces (empty)
        public void CP_logPH2_empty()
        {
            StudentModel model = new StudentModel { studentPassword = "" };

            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentPassword")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "Password required"));
        }
        [TestMethod]
        //Validation Incorrect ( 8 Minimum Characters)
        public void CP_logPH2_incorrect()
        {
            StudentModel model = new StudentModel { studentPassword = "calza12" };

            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentPassword")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "Password needs to have a minimum of 8 characters"));
        }
        [TestMethod]
        //Validation Correct ( 8 Minimum Characters)
        public void CP_logPH2_correct()
        {
            StudentModel model = new StudentModel { studentPassword = "luis123456" };

            var result = ValidateModel(model);

            Assert.IsFalse(result.Any(x => x.MemberNames.Contains("studentPassword")));
        }


        // VALIDATION - LOGIN
        [TestMethod]
        //Validation Empty User Data
        public void CP_log1_empty()
        {
            StudentModel model = new StudentModel { studentEmail = "", studentPassword = "" };

            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentPassword")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "Password required"));
            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentEmail")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "Email required"));

        }
        [TestMethod]
        public async Task probarLoginIncorrecto()
        {
            var dbcontext = await GetContext.GetDatabaseContextAsync();
            var studentController = new StudentController(dbcontext);
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            studentController.TempData = tempData;
            StudentModel model = new() { studentEmail = "luiss@gmail.com", studentPassword = "12345678911" };

            var result = studentController.Login(model) as ViewResult;
            var tempResult = studentController.TempData["errorLogin"].ToString();


            Assert.AreEqual("Login", result.ViewName);
            Assert.IsTrue(tempResult.Equals("This user does not exist or check the information"));
        }

        /*
        // TO-DO 
        [TestMethod]
        public async Task probarLoginCorrecto()
        {
            var dbcontext = await GetContext.GetDatabaseContextAsync();
            var studentController = new StudentController(dbcontext);
            StudentModel model = new() { studentEmail = "test@gmail.com", studentPassword = "123456789" };

            var result = studentController.Login(model) as ViewResult;

            Assert.AreEqual("Home", result.ViewName);
        }
        */


        //REGISTER - PLACEHOLDER
        [TestMethod]
        //Validation User Name Data
        public void CP_RegPH1_NameEmpty()
        {
            StudentModel model = new StudentModel { studentNames = "" };
            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentNames")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "Name required"));
        }
        [TestMethod]
        public void CP_RegPH1_NameCapital()
        {
            StudentModel model = new StudentModel { studentNames = "marco" };
            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentNames")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "First character must be in capital letters, numbers are not accepted"));
        }
        [TestMethod]
        public void CP_RegPH1_NameNumber()
        {
            StudentModel model = new StudentModel { studentNames = "Marco6" };
            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentNames")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "First character must be in capital letters, numbers are not accepted"));
        }
        [TestMethod]
        public void CP_RegPH1_NameCorrect()
        {
            StudentModel model = new StudentModel { studentNames = "Luis" };
            var result = ValidateModel(model);

            Assert.IsFalse(result.Any(x => x.MemberNames.Contains("studentNames")));
        }

        //Validation User Last Name Data
        [TestMethod]
        public void CP_RegPH1_LastNameEmpty()
        {
            StudentModel model = new StudentModel { studentLastNames = "" };
            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentLastNames")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "Last name required"));
        }
        [TestMethod]
        public void CP_RegPH1_LastNameCapital()
        {
            StudentModel model = new StudentModel { studentLastNames = "parra" };
            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentLastNames")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "First character must be in capital letters, numbers are not accepted"));
        }
        [TestMethod]
        public void CP_RegPH1_LastNameNumber()
        {
            StudentModel model = new StudentModel { studentLastNames = "Parra5" };
            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentLastNames")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "First character must be in capital letters, numbers are not accepted"));
        }
        [TestMethod]
        public void CP_RegPH1_LastNameCorrect()
        {
            StudentModel model = new StudentModel { studentLastNames = "Marques" };
            var result = ValidateModel(model);

            Assert.IsFalse(result.Any(x => x.MemberNames.Contains("studentLastNames")));
        }

        //Validation User Email Data
        [TestMethod]
        public void CP_RegPH1_EmailEmpty()
        {
            StudentModel model = new StudentModel { studentEmail = "" };
            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentEmail")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "Email required"));
        }
        [TestMethod]
        public void CP_RegPH1_EmailIncorrect()
        {
            StudentModel model = new StudentModel { studentEmail = "marcoparra2@.com" };
            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentEmail")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "The Email field is not a valid e-mail address"));
        }
        [TestMethod]
        public void CP_RegPH1_EmailCorrect()
        {
            StudentModel model = new StudentModel { studentEmail = "jmarcoparra2@hotmail.com" };
            var result = ValidateModel(model);

            Assert.IsFalse(result.Any(x => x.MemberNames.Contains("studentEmail")));
        }

        //Validation User Password Data
        [TestMethod]
        public void CP_RegPH1_PassEmpty()
        {
            StudentModel model = new StudentModel { studentPassword = "       " };
            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentPassword")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "Password required"));
        }
        [TestMethod]
        public void CP_RegPH1_PassIncorrect()
        {
            StudentModel model = new StudentModel { studentPassword = "1234567" };
            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentPassword")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "Password needs to have a minimum of 8 characters"));
        }
        [TestMethod]
        public void CP_RegPH1_PassCorrect()
        {
            StudentModel model = new StudentModel { studentPassword = "123456789Luis" };
            var result = ValidateModel(model);

            Assert.IsFalse(result.Any(x => x.MemberNames.Contains("studentPassword")));
        }

        //Validation User Confirm Password Data
        [TestMethod]
        public void CP_RegPH1_CPassEmpty()
        {
            StudentModel model = new StudentModel { studentConfirmPassword = "       " };
            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentConfirmPassword")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "Confirm password required"));
        }
        [TestMethod]
        public void CP_RegPH1_CPassIncorrect()
        {
            StudentModel model = new StudentModel { studentPassword = "12345678", studentConfirmPassword = "123456789" };
            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentConfirmPassword")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "Password and confirmation password must match"));
        }
        [TestMethod]
        public void CP_RegPH1_CPassCorrect()
        {
            StudentModel model = new StudentModel { studentPassword = "123456789", studentConfirmPassword = "123456789" };
            var result = ValidateModel(model);

            Assert.IsFalse(result.Any(x => x.MemberNames.Contains("studentConfirmPassword")));
        }

        //Validation User Career Data
        [TestMethod]
        public void CP_RegPH1_CareerEmpty()
        {
            StudentModel model = new StudentModel { studentCareer = "" };
            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentCareer")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "Career required"));
        }
        [TestMethod]
        public void CP_RegPH1_CareerIncorrect()
        {
            StudentModel model = new StudentModel { studentCareer = "ingenieria" };
            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentCareer")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "First character must be in capital letters, numbers are not accepted"));
        }
        [TestMethod]
        public void CP_RegPH1_CareerCorrect()
        {
            StudentModel model = new StudentModel { studentCareer = "Ingenieria de Sistemas y Computacion" };
            var result = ValidateModel(model);

            Assert.IsFalse(result.Any(x => x.MemberNames.Contains("studentCareer")));
        }

        //Validation User Semester Data
        [TestMethod]
        public void CP_RegPH1_SemesterIncorrect()
        {
            StudentModel model = new StudentModel { studentSemester = 16 };
            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentSemester")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "Semester must be between 1 and 15"));
        }
        [TestMethod]
        public void CP_RegPH1_SemesterCorrect()
        {
            StudentModel model = new StudentModel { studentSemester = 5 };
            var result = ValidateModel(model);

            Assert.IsFalse(result.Any(x => x.MemberNames.Contains("studentSemester")));
        }

        //Validation User Career Data
        [TestMethod]
        public void CP_RegPH1_CountryEmpty()
        {
            StudentModel model = new StudentModel { studentCountry = "" };
            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentCountry")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "Country required"));
        }
        [TestMethod]
        public void CP_RegPH1_CountryIncorrect()
        {
            StudentModel model = new StudentModel { studentCountry = "colombia" };
            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.MemberNames.Contains("studentCountry")));
            Assert.IsTrue(result.Any(x => x.ErrorMessage == "First character must be in capital letters, numbers are not accepted"));
        }
        [TestMethod]
        public void CP_RegPH1_CountryCorrect()
        {
            StudentModel model = new StudentModel { studentCountry = "Colombia" };
            var result = ValidateModel(model);

            Assert.IsFalse(result.Any(x => x.MemberNames.Contains("studentCountry")));
        }



        // VALIDATION - REGISTER
        [TestMethod]
        public async Task CP_Reg1_PasswordAndCPasswordAsync()
        {
            var dbcontext = await GetContext.GetDatabaseContextAsync();
            var studentController = new StudentController(dbcontext);
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            studentController.TempData = tempData;
            StudentModel model = new() {

                studentId = Guid.NewGuid(),
                studentNames = "Marco",
                studentLastNames = "Parra",
                studentPassword = "12345678",
                studentConfirmPassword = "123456789",
                studentEmail = "marcoparra2@hotmail.com",
                studentCountry = "Colombia",
                studentSemester = 5,
                studentCareer = "Sistemas",
                studentBio = "Agt Javascript"

            };

            var result = ValidateModel(model);

            Assert.IsTrue(result.Any(x => x.ErrorMessage == "Password and confirmation password must match"));

        }
        [TestMethod]
        public async Task CP_Reg1_EmailExists()
        {
            var dbcontext = await GetContext.GetDatabaseContextAsync();
            var studentController = new StudentController(dbcontext);
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            studentController.TempData = tempData;

            StudentModel model = new()
            {

                studentId = Guid.NewGuid(),
                studentNames = "TestBoy",
                studentLastNames = "BoyTest",
                studentPassword = "123456789",
                studentConfirmPassword = "123456789",
                studentEmail = "context@admin.com",
                studentCountry = "Colombia",
                studentSemester = 5,
                studentCareer = "Sistemas",
                studentBio = "Agt Javascript"

            };


            dbcontext.Add(model);
            dbcontext.SaveChanges();

            var result = studentController.EmailExistenceValidation("context@admin.com");

            Assert.IsTrue(result);


        }
        
        [TestMethod]
        public async Task CP_Reg1_Correct()
        {
            var dbcontext = await GetContext.GetDatabaseContextAsync();
            var studentController = new StudentController(dbcontext);
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            studentController.TempData = tempData;

            StudentModel model = new()
            {
                studentId = Guid.NewGuid(),
                studentNames = "Register",
                studentLastNames = "Correct",
                studentPassword = "123456789",
                studentConfirmPassword = "123456789",
                studentEmail = "regCorrect@admin.com",
                studentCountry = "Colombia",
                studentSemester = 5,
                studentCareer = "Sistemas",
                studentBio = "Agt Javascript"
            };

            var result = studentController.Register(model) as ViewResult;
            var tempResult = studentController.TempData["successRegister"].ToString();


            Assert.AreEqual("Login", result.ViewName);
            Assert.IsTrue(tempResult.Equals("Account created successfully!"));

        }

        
        // LOGOUT
        /*
        [TestMethod]
        public async Task CP_Logout1Async()
        {
            var dbcontext = await GetContext.GetDatabaseContextAsync();
            var studentController = new StudentController(dbcontext);

            var result = studentController.Logout() as ViewResult;

            Assert.AreEqual("Login", result.ViewName);
        }*/



        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
   
    [TestClass]
    public class StudyControllerTests
    {
        public static Guid identificador = Guid.NewGuid();

        public static class GetContext
        {
            private static IConfigurationRoot _configuration;
            public static async Task<DatabaseContext> GetDatabaseContextAsync()
            {
                var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json");

                _configuration = builder.Build();
                var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer(_configuration.GetConnectionString("SQLServerConnection")).Options;
                var databaseContext = new DatabaseContext(options);
                databaseContext.Database.EnsureCreated();
                return databaseContext;
            }

        }


        //Validate Add Study
        [TestMethod]
        public async Task CP_YPae1_Add_Correct()
        {
            var dbcontext = await GetContext.GetDatabaseContextAsync();
            var studyController = new StudyController(dbcontext);
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            studyController.TempData = tempData;

            StudyModel model = new()
            {
                studyId = identificador,
                studentId = Guid.NewGuid(),
                studyYear = 2016,
                studyGrade = "Profesional",
                studyName = "Sergio Arboleda",
                studyPlace = "Universidad",
                studyCity = "",
                studyCountry = ""
            };

            studyController.AddStudy(model);
            var tempResult = studyController.TempData["successStudyAdd"].ToString();
            Assert.IsTrue(tempResult.Equals("Study added successfully!"));
        }

        //Validate Update Study Incorrect
        [TestMethod]
        public async Task CP_YPee1_Update_Incorrect()
        {
            var dbcontext = await GetContext.GetDatabaseContextAsync();
            var studyController = new StudyController(dbcontext);
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            studyController.TempData = tempData;

            StudyModel model = new()
            {
                studyYear = 2016,
                studyGrade = "Profesional",
                studyName = "Manuela Beltran",
                studyPlace = "Universidad",
                studyCity = "",
                studyCountry = ""
            };

            studyController.UpdateStudy(identificador,model);
            var tempResult = studyController.TempData["errorUpdatingStudy"].ToString();
            Assert.IsTrue(tempResult.Equals("Study could not be updated"));
        }

        //Validate Delete Study Correct
        [TestMethod]
        public async Task CP_YPde1_Delete_Correct()
        {
            var dbcontext = await GetContext.GetDatabaseContextAsync();
            var studyController = new StudyController(dbcontext);
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            studyController.TempData = tempData;

            Guid testGuid = Guid.NewGuid();
            StudyModel modelTest = new()
            {
                studyId = testGuid,
                studentId = Guid.NewGuid(),
                studyYear = 2016,
                studyGrade = "Profesional",
                studyName = "Sergio Arboleda",
                studyPlace = "Universidad",
                studyCity = "",
                studyCountry = ""
            };

            dbcontext.Study.Add(modelTest);
            dbcontext.SaveChanges();

            studyController.DeleteStudy(testGuid);

            var tempResult = studyController.TempData["successDeletingStudy"].ToString();
            Assert.IsTrue(tempResult.Equals("Study deleted successfully!"));
        }


    }

    /*
    [TestClass]
    public class PortfolioControllerTests
    {

        public static class GetContext
        {
            private static IConfigurationRoot _configuration;
            public static async Task<DatabaseContext> GetDatabaseContextAsync()
            {
                var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json");

                _configuration = builder.Build();
                var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer(_configuration.GetConnectionString("SQLServerConnection")).Options;
                var databaseContext = new DatabaseContext(options);
                databaseContext.Database.EnsureCreated();
                return databaseContext;
            }

        }

        [TestMethod]
        public async Task CP_YPawe1_AddExperience_Correct()
        {
            var dbcontext = await GetContext.GetDatabaseContextAsync();
            var portfolioController = new PortfolioController(dbcontext);
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            portfolioController.TempData = tempData;

            ExperienceModel modelexp = new()
            {
                experienceName = "TestExperience",
                experiencePlace = "TestPlace",
                experienceEntity = "TestEntity",
                experienceDescription = "TestDescription",
                experienceStartDate = DateTime.Now,
                experienceEndDate = DateTime.Now
            };

            var result = (RedirectToActionResult)portfolioController.AddWorkExperience(modelexp);
            result.RouteValues["action"].Equals("Portfolio");
            Assert.AreEqual("Portfolio", result.RouteValues["action"]);


        }
    }
    */
}
