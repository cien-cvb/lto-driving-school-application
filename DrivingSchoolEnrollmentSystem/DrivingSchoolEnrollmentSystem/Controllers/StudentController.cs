using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using DrivingSchoolEnrollmentSystem.Utilities;
using DrivingSchoolEnrollmentSystem.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace DrivingSchoolEnrollmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public StudentController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        DataTable DT;
        SQLHelper sqlHelper;

        [HttpGet]
        public JsonResult Get()
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            DT = new DataTable();
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "SELECT * FROM [dbo].[Student] WHERE DeleteFlag = 0 ORDER BY StudentID ASC";
            DT = sqlHelper.GetDataTable();

            return new JsonResult(DT);
        }

        [HttpPost]
        public JsonResult Insert(Student student)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spStudent";
            sqlHelper.APCommandType = CommandType.StoredProcedure;

            //Personal Information
            sqlHelper.AddParameter("@FirstName", student.FirstName);
            sqlHelper.AddParameter("@LastName", student.LastName);
            sqlHelper.AddParameter("@MiddleName", student.MiddleName);
            sqlHelper.AddParameter("@Suffix", student.Suffix);
            sqlHelper.AddParameter("@Email", student.Email);
            sqlHelper.AddParameter("@ContactNumber", student.ContactNumber);
            sqlHelper.AddParameter("@Nationality", student.Nationality);
            sqlHelper.AddParameter("@Gender", student.Gender);
            sqlHelper.AddParameter("@MaritalStatus", student.MaritalStatus);
            //sqlHelper.AddParameter("@BirthDate", student.BirthDate);
            sqlHelper.AddParameter("@DriversLicenseNo", student.DriversLicenseNo);

            sqlHelper.AddParameter("@DateCreated", student.DateCreated);
            sqlHelper.AddParameter("@DateModified", student.DateModified);

            //Attachments
            sqlHelper.AddParameter("@ProfilePicture", student.ProfilePicture);
            sqlHelper.AddParameter("@Attachment", student.Attachments);

            //Fingerprints
            sqlHelper.AddParameter("@RightThumbTemplate", student.RightThumbTemplate);
            sqlHelper.AddParameter("@RightIndexTemplate", student.RightIndexTemplate);
            sqlHelper.AddParameter("@RightMiddleTemplate", student.RightMiddleTemplate);
            sqlHelper.AddParameter("@RightRingTemplate", student.RightRingTemplate);
            sqlHelper.AddParameter("@RightPinkyTemplate", student.RightPinkyTemplate);
            sqlHelper.AddParameter("@LeftThumbTemplate", student.LeftThumbTemplate);
            sqlHelper.AddParameter("@LeftIndexTemplate", student.LeftIndexTemplate);
            sqlHelper.AddParameter("@LeftMiddleTemplate", student.LeftMiddleTemplate);
            sqlHelper.AddParameter("@LeftRingTemplate", student.LeftRingTemplate);
            sqlHelper.AddParameter("@LeftPinkyTemplate", student.LeftPinkyTemplate);

            //Address Information
            if (student.Province != null)
            {
                sqlHelper.AddParameter("@Province", student.Province);
            }

            sqlHelper.AddParameter("@HomeBuildingNo", student.HomeBuildingNo);
            sqlHelper.AddParameter("@City", student.City);
            sqlHelper.AddParameter("@Street", student.Street);
            sqlHelper.AddParameter("@Barangay", student.Barangay);
            sqlHelper.AddParameter("@PostalCode", student.PostalCode);

            sqlHelper.AddParameter("@action", "Insert");

            return new JsonResult("Student: " + student.LastName + ", " + student.FirstName + " " + student.MiddleName + " " + student.Suffix + " Added Successfully"); 
        }

        [HttpPut]
        public JsonResult Update(Student student)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spStudent";
            sqlHelper.APCommandType = CommandType.StoredProcedure;

            //Personal Information
            sqlHelper.AddParameter("@FirstName", student.FirstName);
            sqlHelper.AddParameter("@LastName", student.LastName);
            sqlHelper.AddParameter("@MiddleName", student.MiddleName);
            sqlHelper.AddParameter("@Suffix", student.Suffix);
            sqlHelper.AddParameter("@Email", student.Email);
            sqlHelper.AddParameter("@ContactNumber", student.ContactNumber);
            sqlHelper.AddParameter("@Nationality", student.Nationality);
            sqlHelper.AddParameter("@Gender", student.Gender);
            sqlHelper.AddParameter("@MaritalStatus", student.MaritalStatus);
            sqlHelper.AddParameter("@BirthDate", student.BirthDate);
            sqlHelper.AddParameter("@DriversLicenseNo", student.DriversLicenseNo);

            sqlHelper.AddParameter("@DateCreated", student.DateCreated);
            sqlHelper.AddParameter("@DateModified", student.DateModified);

            //Attachments
            sqlHelper.AddParameter("@ProfilePicture", student.ProfilePicture);
            sqlHelper.AddParameter("@Attachments", student.Attachments);

            //Fingerprints
            sqlHelper.AddParameter("@RightThumbTemplate", student.RightThumbTemplate);
            sqlHelper.AddParameter("@RightIndexTemplate", student.RightIndexTemplate);
            sqlHelper.AddParameter("@RightMiddleTemplate", student.RightMiddleTemplate);
            sqlHelper.AddParameter("@RightRingTemplate", student.RightRingTemplate);
            sqlHelper.AddParameter("@RightPinkyTemplate", student.RightPinkyTemplate);
            sqlHelper.AddParameter("@LeftThumbTemplate", student.LeftThumbTemplate);
            sqlHelper.AddParameter("@LeftIndexTemplate", student.LeftIndexTemplate);
            sqlHelper.AddParameter("@LeftMiddleTemplate", student.LeftMiddleTemplate);
            sqlHelper.AddParameter("@LeftRingTemplate", student.LeftRingTemplate);
            sqlHelper.AddParameter("@LeftPinkyTemplate", student.LeftPinkyTemplate);

            //Address Information
            if (student.Province != null)
            {
                sqlHelper.AddParameter("@Province", student.Province);
            }

            sqlHelper.AddParameter("@HomeBuildingNo", student.HomeBuildingNo);
            sqlHelper.AddParameter("@City", student.City);
            sqlHelper.AddParameter("@Street", student.Street);
            sqlHelper.AddParameter("@Barangay", student.Barangay);
            sqlHelper.AddParameter("@PostalCode", student.PostalCode);

            sqlHelper.AddParameter("@action", "Update");

            return new JsonResult("Student: " + student.LastName + ", " + student.FirstName + " " + student.MiddleName + " " + student.Suffix + " Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spStudent";
            sqlHelper.APCommandType = CommandType.StoredProcedure;
            sqlHelper.AddParameter("@StudentID", id);

            sqlHelper.AddParameter("@action", "Delete");

            return new JsonResult("Student Deleted Successfully");
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + fileName;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(fileName);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }

        [Route("GetAllCoursesNames")]
        public JsonResult GetAllCoursesNames()
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            DT = new DataTable();
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "SELECT CourseName FROM [dbo].[Course] WHERE DeleteFlag = 0 ORDER BY CourseName ASC";
            DT = sqlHelper.GetDataTable();

            return new JsonResult(DT);
        }
    }
}