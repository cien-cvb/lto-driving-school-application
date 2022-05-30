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

    public class EnrollmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EnrollmentController(IConfiguration configuration)
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

            sqlHelper.APCommandText = "SELECT E.EnrollmentNo AS 'Enrollment Number', " +
                                      "E.EnrollmentDate AS 'Date', " +
                                      "CONCAT(S.LastName, ', ' , S.FirstName,  ' ',  S.MiddleName, ' ',  S.Suffix) AS 'Student', " +
                                      "E.Amount, " +
                                      "ET.EnrollmentTypeName AS 'Training Purpose', " +
                                      "C.CourseName AS 'Course Name', " +
                                      "CONCAT(I.LastName, ', ' , I.FirstName,  ' ',  I.MiddleName, ' ',  I.Suffix) AS 'Instructor', " +
                                      "MVT.MVTypeName AS 'MV Type Used', " +
                                      " FROM [dbo].[Enrollment] AS E INNER JOIN [dbo].[Student] AS S ON E.StudentID = S.StudentID " +
                                      "INNER JOIN [dbo].[EnrollmentType] AS ET ON E.EnrollmentTypeID = ET.EnrollmentTypeID " +
                                      "INNER JOIN [dbo].[Course] AS C ON E.CourseID = C.CourseID " +
                                      "INNER JOIN [dbo].[Instructor] AS I ON E.InstructorID = I.InstructorID " +
                                      "INNER JOIN [dbo].[MotorVehicleType] AS MVT ON E.MVTypeID = MVT.MVTypeID" +
                                      " WHERE E.DeleteFlag = 0 ORDER BY E.EnrollmentNo ASC";
            DT = sqlHelper.GetDataTable();

            return new JsonResult(DT);
        }

        [HttpPost]
        public JsonResult Insert(Enrollment enrollment)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spEnrollment";
            sqlHelper.APCommandType = CommandType.StoredProcedure;
            sqlHelper.AddParameter("@EnrollmentNo", enrollment.EnrollmentNo);
            sqlHelper.AddParameter("@StudentID", enrollment.StudentID);
            sqlHelper.AddParameter("@InstructorID", enrollment.InstructorID);
            sqlHelper.AddParameter("@CourseID", enrollment.CourseID);
            sqlHelper.AddParameter("@MVTypeID", enrollment.MVTypeID);
            sqlHelper.AddParameter("@EnrollmentTypeID", enrollment.EnrollmentTypeID);
            sqlHelper.AddParameter("@Amount", enrollment.EnrollmentNo);
            sqlHelper.AddParameter("@Assessment", enrollment.StudentID);
            sqlHelper.AddParameter("@OverAllRating", enrollment.InstructorID);
            sqlHelper.AddParameter("@DateStarted", enrollment.CourseID);
            sqlHelper.AddParameter("@DateCompleted", enrollment.MVTypeID);
            sqlHelper.AddParameter("@Remarks", enrollment.EnrollmentTypeID);
            sqlHelper.AddParameter("@DateCreated", enrollment.DateCreated);
            sqlHelper.AddParameter("@DateModified", enrollment.DateModified);

            sqlHelper.AddParameter("@action", "Insert");

            return new JsonResult("Course: " + enrollment.EnrollmentNo + " Added Successfully");
        }

        [HttpPut]
        public JsonResult Update(Enrollment enrollment)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spEnrollment";
            sqlHelper.APCommandType = CommandType.StoredProcedure;
            sqlHelper.AddParameter("@EnrollmentNo", enrollment.EnrollmentNo);
            sqlHelper.AddParameter("@StudentID", enrollment.StudentID);
            sqlHelper.AddParameter("@InstructorID", enrollment.InstructorID);
            sqlHelper.AddParameter("@CourseID", enrollment.CourseID);
            sqlHelper.AddParameter("@MVTypeID", enrollment.MVTypeID);
            sqlHelper.AddParameter("@EnrollmentTypeID", enrollment.EnrollmentTypeID);
            sqlHelper.AddParameter("@Amount", enrollment.EnrollmentNo);
            sqlHelper.AddParameter("@Assessment", enrollment.StudentID);
            sqlHelper.AddParameter("@OverAllRating", enrollment.InstructorID);
            sqlHelper.AddParameter("@DateStarted", enrollment.CourseID);
            sqlHelper.AddParameter("@DateCompleted", enrollment.MVTypeID);
            sqlHelper.AddParameter("@Remarks", enrollment.EnrollmentTypeID);
            sqlHelper.AddParameter("@DateCreated", enrollment.DateCreated);
            sqlHelper.AddParameter("@DateModified", enrollment.DateModified);

            sqlHelper.AddParameter("@action", "Update");

            return new JsonResult("Enrollment: " + enrollment.EnrollmentNo + " Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spEnrollment";
            sqlHelper.APCommandType = CommandType.StoredProcedure;
            sqlHelper.AddParameter("@EnrollmentID", id);

            sqlHelper.AddParameter("@action", "Delete");

            return new JsonResult("Enrollment Deleted Successfully");
        }
    }
}

