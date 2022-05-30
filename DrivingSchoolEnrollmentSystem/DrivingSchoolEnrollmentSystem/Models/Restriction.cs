using System;

namespace DrivingSchoolEnrollmentSystem.Models
{
    public class Restriction    
    {
        public int RestrictionID { get; set; }
        public string RestrictionName { get; set; }
        public string RestrictionCode { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
