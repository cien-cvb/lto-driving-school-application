using System;

namespace DrivingSchoolEnrollmentSystem.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public int EnrollmentTypeID { get; set; }
        public int MVTypeID { get; set; }
        public int InstructorID { get; set; }
        public string EnrollmentNo { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public decimal Amount { get; set; }
        public int TotalHoursTaken { get; set; }
        public string DLCodes { get; set; }
        public bool Assessment { get; set; }
        public bool OverAllRating { get; set; }
        public string Remarks { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateCompleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}

