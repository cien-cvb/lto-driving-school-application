using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrivingSchoolEnrollmentSystem.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string HomeBuildingNo { get; set; }
        public string Street { get; set; }    
        public string Province { get; set; }
        public string City { get; set; }
        public string Barangay { get; set; }
        public string PostalCode { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime BirthDate { get; set; }
        public string DriversLicenseNo { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string ProfilePicture { get; set; }
        public string Attachments { get; set; }
        public string RightThumbTemplate { get; set; }
        public string RightIndexTemplate { get; set; }
        public string RightMiddleTemplate { get; set; }
        public string RightRingTemplate { get; set; }
        public string RightPinkyTemplate { get; set; }
        public string LeftThumbTemplate { get; set; }
        public string LeftIndexTemplate { get; set; }
        public string LeftMiddleTemplate { get; set; }
        public string LeftRingTemplate { get; set; }
        public string LeftPinkyTemplate { get; set; }
    }
}
