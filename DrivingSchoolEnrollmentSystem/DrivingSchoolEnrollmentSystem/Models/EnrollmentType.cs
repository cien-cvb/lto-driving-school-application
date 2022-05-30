using System;

namespace DrivingSchoolEnrollmentSystem.Models
{
    public class EnrollmentType
    {
        public int EnrollmentTypeID { get; set; }
        public string EnrollmentTypeName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}

