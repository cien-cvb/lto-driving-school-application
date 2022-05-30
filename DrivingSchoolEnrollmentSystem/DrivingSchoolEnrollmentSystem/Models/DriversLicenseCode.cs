using System;

namespace DrivingSchoolEnrollmentSystem.Models
{
    public class DriversLicenseCode
    {
        public int DLCodeID { get; set; }
        public string DLCodeCategory { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}

