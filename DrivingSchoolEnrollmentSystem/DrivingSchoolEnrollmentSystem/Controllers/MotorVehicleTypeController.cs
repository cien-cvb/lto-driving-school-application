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

    public class MotorVehicleTypeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MotorVehicleTypeController(IConfiguration configuration)
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

            sqlHelper.APCommandText = "SELECT * FROM [dbo].[MotorVehicleType] WHERE DeleteFlag = 0 ORDER BY MVTypeName ASC";
            DT = sqlHelper.GetDataTable();

            return new JsonResult(DT);
        }

        [HttpPost]
        public JsonResult Insert(MotorVehicleType mvType)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spMotorVehicleType";
            sqlHelper.APCommandType = CommandType.StoredProcedure;
            sqlHelper.AddParameter("@MVTypeName", mvType.MVTypeName);
            sqlHelper.AddParameter("@DateCreated", mvType.DateCreated);
            sqlHelper.AddParameter("@DateModified", mvType.DateModified);

            sqlHelper.AddParameter("@action", "Insert");

            return new JsonResult("Motor Vehicle Type: " + mvType.MVTypeName + " Added Successfully");
        }

        [HttpPut]
        public JsonResult Update(MotorVehicleType mvType)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spMotorVehicleType";
            sqlHelper.APCommandType = CommandType.StoredProcedure;
            sqlHelper.AddParameter("@EnrollmentTypeID", mvType.MVTypeID);
            sqlHelper.AddParameter("@EnrollmentTypeName", mvType.MVTypeName);
            sqlHelper.AddParameter("@DateModified", mvType.DateModified);

            sqlHelper.AddParameter("@action", "Update");

            return new JsonResult("Motor Vehicle Type: " + mvType.MVTypeName + " Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spMotorVehicleType";
            sqlHelper.APCommandType = CommandType.StoredProcedure;
            sqlHelper.AddParameter("@EnrollmentTypeID", id);

            sqlHelper.AddParameter("@action", "Delete");

            return new JsonResult("Motor Vehicle Type Deleted Successfully");
        }
    }
}



