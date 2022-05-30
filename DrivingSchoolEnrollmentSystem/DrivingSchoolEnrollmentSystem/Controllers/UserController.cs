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

    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
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

            sqlHelper.APCommandText = "SELECT * FROM [dbo].[Users] WHERE DeleteFlag = 0 ORDER BY UserID ASC";
            DT = sqlHelper.GetDataTable();

            return new JsonResult(DT);
        }

        [HttpPost]
        public JsonResult Insert(Users users)
        {
            DataSet DS = new DataSet();
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandType = CommandType.StoredProcedure;
            sqlHelper.APCommandText = "dbo.spUsers";
            sqlHelper.AddParameter("@UserName", users.CourseName);
            sqlHelper.AddParameter("@UserTypeID", users.CourseType);
            sqlHelper.AddParameter("@UserName", users.CourseHours);

            sqlHelper.AddParameter("@action", "Insert");
            DS = sqlHelper.GetDataSet();

            return new JsonResult("Course: " + course.CourseName + " Added Successfully");
        }

        [HttpPut]
        public JsonResult Update(Course course)
        {
            DataSet DS = new DataSet();
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandType = CommandType.StoredProcedure;
            sqlHelper.APCommandText = "dbo.spCourse";
            sqlHelper.AddParameter("@CourseID", course.CourseID);
            sqlHelper.AddParameter("@CourseName", course.CourseName);
            sqlHelper.AddParameter("@CourseType", course.CourseType);
            sqlHelper.AddParameter("@CourseHours", course.CourseHours);

            sqlHelper.AddParameter("@action", "Update");
            DS = sqlHelper.GetDataSet();

            return new JsonResult("Course: " + course.CourseName + " Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(Course course)
        {
            DataSet DS = new DataSet();
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandType = CommandType.StoredProcedure;
            sqlHelper.APCommandText = "dbo.spCourse";
            sqlHelper.AddParameter("@CourseID", course.CourseID);

            sqlHelper.AddParameter("@action", "Delete");
            DS = sqlHelper.GetDataSet();

            return new JsonResult("Course Deleted Successfully");
        }
    }
}

