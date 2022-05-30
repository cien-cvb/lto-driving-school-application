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

    public class DriversLicenseCodeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DriversLicenseCodeController(IConfiguration configuration)
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

            sqlHelper.APCommandText = "SELECT * FROM [dbo].[DriversLicenseCode] WHERE DeleteFlag = 0 ORDER BY DLCodeCategory ASC";
            DT = sqlHelper.GetDataTable();

            return new JsonResult(DT);
        }

        [HttpPost]
        public JsonResult Insert(DriversLicenseCode dlCode)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spDriversLicenseCode";
            sqlHelper.APCommandType = CommandType.StoredProcedure;
            sqlHelper.AddParameter("@DLCodeCategory", dlCode.DLCodeCategory);
            sqlHelper.AddParameter("@DateCreated", dlCode.DateCreated);
            sqlHelper.AddParameter("@DateModified", dlCode.DateModified);

            sqlHelper.AddParameter("@action", "Insert");

            return new JsonResult("Drivers License Code: " + dlCode.DLCodeCategory + " Added Successfully");
        }

        [HttpPut]
        public JsonResult Update(DriversLicenseCode dlCode)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spDriversLicenseCode";
            sqlHelper.APCommandType = CommandType.StoredProcedure;
            sqlHelper.AddParameter("@DLCodeID", dlCode.DLCodeID);
            sqlHelper.AddParameter("@DLCodeCategory", dlCode.DLCodeCategory);
            sqlHelper.AddParameter("@DateModified", dlCode.DateModified);

            sqlHelper.AddParameter("@action", "Update");

            return new JsonResult("Drivers License Code: " + dlCode.DLCodeCategory + " Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string connString = _configuration.GetConnectionString("ConnectionString");
            sqlHelper = new SQLHelper();
            sqlHelper.ConnString = connString;

            sqlHelper.APCommandText = "dbo.spDriversLicenseCode";
            sqlHelper.APCommandType = CommandType.StoredProcedure;
            sqlHelper.AddParameter("@DLCodeID", id);

            sqlHelper.AddParameter("@action", "Delete");

            return new JsonResult("Drivers License Code Deleted Successfully");
        }
    }
}




