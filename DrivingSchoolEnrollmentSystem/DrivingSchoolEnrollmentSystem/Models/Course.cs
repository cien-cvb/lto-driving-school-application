using System;

namespace DrivingSchoolEnrollmentSystem.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseType { get; set; }
        public int CourseHours { get; set; }
        public DateTime DateCreated  { get; set; }
        public DateTime DateModified { get; set; }
    }
}
