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

    public class InstructorController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public InstructorController(IConfiguration configuration, IWebHostEnvironment env)
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

            sqlHelper.APCommandText = "SELECT * FROM [dbo].[Instructor] WHERE DeleteFlag = 0 ORDER BY LastName ASC";
            DT = sqlHelper.GetDataTable();

            return new JsonResult(DT);
        }

        [HttpPost]
        public JsonResult Insert(Instructor instructor)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spInstructor";
            sqlHelper.APCommandType = CommandType.StoredProcedure;

            //Personal Information
            sqlHelper.AddParameter("@AccreditedNo", instructor.AccreditedNo);
            sqlHelper.AddParameter("@FirstName", instructor.FirstName);
            sqlHelper.AddParameter("@LastName", instructor.LastName);
            sqlHelper.AddParameter("@MiddleName", instructor.MiddleName);
            sqlHelper.AddParameter("@Suffix", instructor.Suffix);
            sqlHelper.AddParameter("@Email", instructor.Email);
            sqlHelper.AddParameter("@ContactNumber", instructor.ContactNumber);
            sqlHelper.AddParameter("@Nationality", instructor.Nationality);
            sqlHelper.AddParameter("@Gender", instructor.Gender);
            sqlHelper.AddParameter("@MaritalStatus", instructor.MaritalStatus);
            sqlHelper.AddParameter("@BirthDate", instructor.BirthDate);

            sqlHelper.AddParameter("@DateCreated", instructor.DateCreated);
            sqlHelper.AddParameter("@DateModified", instructor.DateModified);

            //Attachments
            sqlHelper.AddParameter("@ProfilePicture", instructor.ProfilePicture);
            sqlHelper.AddParameter("@Attachments", instructor.Attachments);

            //Fingerprints
            sqlHelper.AddParameter("@RightThumbTemplate", instructor.RightThumbTemplate);
            sqlHelper.AddParameter("@RightIndexTemplate", instructor.RightIndexTemplate);
            sqlHelper.AddParameter("@RightMiddleTemplate", instructor.RightMiddleTemplate);
            sqlHelper.AddParameter("@RightRingTemplate", instructor.RightRingTemplate);
            sqlHelper.AddParameter("@RightPinkyTemplate", instructor.RightPinkyTemplate);
            sqlHelper.AddParameter("@LeftThumbTemplate", instructor.LeftThumbTemplate);
            sqlHelper.AddParameter("@LeftIndexTemplate", instructor.LeftIndexTemplate);
            sqlHelper.AddParameter("@LeftMiddleTemplate", instructor.LeftMiddleTemplate);
            sqlHelper.AddParameter("@LeftRingTemplate", instructor.LeftRingTemplate);
            sqlHelper.AddParameter("@LeftPinkyTemplate", instructor.LeftPinkyTemplate);

            //Address Information
            if (instructor.Province != null)
            {
                sqlHelper.AddParameter("@Province", instructor.Province);
            }

            sqlHelper.AddParameter("@HomeBuildingNo", instructor.HomeBuildingNo);
            sqlHelper.AddParameter("@City", instructor.City);
            sqlHelper.AddParameter("@Street", instructor.Street);
            sqlHelper.AddParameter("@Barangay", instructor.Barangay);
            sqlHelper.AddParameter("@PostalCode", instructor.PostalCode);

            sqlHelper.AddParameter("@action", "Insert");

            return new JsonResult("Instructor: " + instructor.LastName + ", " + instructor.FirstName + " " + instructor.MiddleName + " " + instructor.Suffix + " Added Successfully");
        }

        [HttpPut]
        public JsonResult Update(Instructor instructor)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spInstructor";
            sqlHelper.APCommandType = CommandType.StoredProcedure;

            //Personal Information
            sqlHelper.AddParameter("@AccreditedNo", instructor.AccreditedNo);
            sqlHelper.AddParameter("@FirstName", instructor.FirstName);
            sqlHelper.AddParameter("@LastName", instructor.LastName);
            sqlHelper.AddParameter("@MiddleName", instructor.MiddleName);
            sqlHelper.AddParameter("@Suffix", instructor.Suffix);
            sqlHelper.AddParameter("@Email", instructor.Email);
            sqlHelper.AddParameter("@ContactNumber", instructor.ContactNumber);
            sqlHelper.AddParameter("@Nationality", instructor.Nationality);
            sqlHelper.AddParameter("@Gender", instructor.Gender);
            sqlHelper.AddParameter("@MaritalStatus", instructor.MaritalStatus);
            sqlHelper.AddParameter("@BirthDate", instructor.BirthDate);

            sqlHelper.AddParameter("@DateCreated", instructor.DateCreated);
            sqlHelper.AddParameter("@DateModified", instructor.DateModified);

            //Attachments
            sqlHelper.AddParameter("@ProfilePicture", instructor.ProfilePicture);
            sqlHelper.AddParameter("@Attachments", instructor.Attachments);

            //Fingerprints
            sqlHelper.AddParameter("@RightThumbTemplate", instructor.RightThumbTemplate);
            sqlHelper.AddParameter("@RightIndexTemplate", instructor.RightIndexTemplate);
            sqlHelper.AddParameter("@RightMiddleTemplate", instructor.RightMiddleTemplate);
            sqlHelper.AddParameter("@RightRingTemplate", instructor.RightRingTemplate);
            sqlHelper.AddParameter("@RightPinkyTemplate", instructor.RightPinkyTemplate);
            sqlHelper.AddParameter("@LeftThumbTemplate", instructor.LeftThumbTemplate);
            sqlHelper.AddParameter("@LeftIndexTemplate", instructor.LeftIndexTemplate);
            sqlHelper.AddParameter("@LeftMiddleTemplate", instructor.LeftMiddleTemplate);
            sqlHelper.AddParameter("@LeftRingTemplate", instructor.LeftRingTemplate);
            sqlHelper.AddParameter("@LeftPinkyTemplate", instructor.LeftPinkyTemplate);

            //Address Information
            if (instructor.Province != null)
            {
                sqlHelper.AddParameter("@Province", instructor.Province);
            }

            sqlHelper.AddParameter("@HomeBuildingNo", instructor.HomeBuildingNo);
            sqlHelper.AddParameter("@City", instructor.City);
            sqlHelper.AddParameter("@Street", instructor.Street);
            sqlHelper.AddParameter("@Barangay", instructor.Barangay);
            sqlHelper.AddParameter("@PostalCode", instructor.PostalCode);

            sqlHelper.AddParameter("@action", "Update");

            return new JsonResult("Instructor: " + instructor.LastName + ", " + instructor.FirstName + " " + instructor.MiddleName + " " + instructor.Suffix + " Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spInstructor";
            sqlHelper.APCommandType = CommandType.StoredProcedure;
            sqlHelper.AddParameter("@InstructorID", id);

            sqlHelper.AddParameter("@action", "Delete");

            return new JsonResult("Instructor Deleted Successfully");
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
    }
}
