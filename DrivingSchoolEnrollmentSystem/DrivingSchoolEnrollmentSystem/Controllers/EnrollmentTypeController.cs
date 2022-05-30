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

    public class EnrollmentTypeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EnrollmentTypeController(IConfiguration configuration)
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

            sqlHelper.APCommandText = "SELECT * FROM [dbo].[EnrollmentType] WHERE DeleteFlag = 0 ORDER BY EnrollmentTypeName ASC";
            DT = sqlHelper.GetDataTable();

            return new JsonResult(DT);
        }

        [HttpPost]
        public JsonResult Insert(EnrollmentType enrollmentType)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spEnrollmentType";
            sqlHelper.APCommandType = CommandType.StoredProcedure;
            sqlHelper.AddParameter("@RestrictionName", enrollmentType.EnrollmentTypeName);
            sqlHelper.AddParameter("@DateCreated", enrollmentType.DateCreated);
            sqlHelper.AddParameter("@DateModified", enrollmentType.DateModified);

            sqlHelper.AddParameter("@action", "Insert");

            return new JsonResult("Enrollment Type: " + enrollmentType.EnrollmentTypeName + " Added Successfully");
        }

        [HttpPut]
        public JsonResult Update(EnrollmentType enrollmentType)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spEnrollmentType";
            sqlHelper.APCommandType = CommandType.StoredProcedure;
            sqlHelper.AddParameter("@EnrollmentTypeID", enrollmentType.EnrollmentTypeID);
            sqlHelper.AddParameter("@EnrollmentTypeName", enrollmentType.EnrollmentTypeName);
            sqlHelper.AddParameter("@DateModified", enrollmentType.DateModified);

            sqlHelper.AddParameter("@action", "Update");

            return new JsonResult("Enrollment Type: " + enrollmentType.EnrollmentTypeName + " Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spEnrollmentType";
            sqlHelper.APCommandType = CommandType.StoredProcedure;
            sqlHelper.AddParameter("@EnrollmentTypeID", id);

            sqlHelper.AddParameter("@action", "Delete");

            return new JsonResult("Enrollment Type Deleted Successfully");
        }
    }
}


