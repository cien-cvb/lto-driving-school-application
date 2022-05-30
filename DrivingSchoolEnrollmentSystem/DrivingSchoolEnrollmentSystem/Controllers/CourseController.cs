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

    public class CourseController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CourseController(IConfiguration configuration)
        {
            _configuration = configuration;
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

            sqlHelper.APCommandText = "SELECT * FROM [dbo].[Course] WHERE DeleteFlag = 0 ORDER BY CourseName ASC";
            DT = sqlHelper.GetDataTable();

            return new JsonResult(DT);
        }

        [HttpPost]
        public JsonResult Insert(Course course)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spCourse";
            sqlHelper.APCommandType = CommandType.StoredProcedure;
            sqlHelper.AddParameter("@CourseName", course.CourseName);
            sqlHelper.AddParameter("@CourseType", course.CourseType);
            sqlHelper.AddParameter("@CourseHours", course.CourseHours);
            sqlHelper.AddParameter("@DateCreated", course.DateCreated);
            sqlHelper.AddParameter("@DateModified", course.DateModified);

            sqlHelper.AddParameter("@action", "Insert");

            return new JsonResult("Course: " + course.CourseName + " Added Successfully");
        }

        [HttpPut]
        public JsonResult Update(Course course)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spCourse";
            sqlHelper.APCommandType = CommandType.StoredProcedure;
            sqlHelper.AddParameter("@CourseID", course.CourseID);
            sqlHelper.AddParameter("@CourseName", course.CourseName);
            sqlHelper.AddParameter("@CourseType", course.CourseType);
            sqlHelper.AddParameter("@CourseHours", course.CourseHours);
            sqlHelper.AddParameter("@DateModified", course.DateModified);

            sqlHelper.AddParameter("@action", "Update");

            return new JsonResult("Course: " + course.CourseName + " Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spCourse";
            sqlHelper.APCommandType = CommandType.StoredProcedure;
            sqlHelper.AddParameter("@CourseID", id);

            sqlHelper.AddParameter("@action", "Delete");

            return new JsonResult("Course Deleted Successfully");
        }
    }
}
