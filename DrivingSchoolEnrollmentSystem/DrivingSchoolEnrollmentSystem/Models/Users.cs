using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrivingSchoolEnrollmentSystem.Models
{
    public class Users
    {
        public int UserID { get; set; }
        public int UserTypeID { get; set; }
        public int UserName { get; set; }
        public int UserSalt { get; set; }
        public int UserPasswordHash { get; set; }
        public int LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
    }
}
