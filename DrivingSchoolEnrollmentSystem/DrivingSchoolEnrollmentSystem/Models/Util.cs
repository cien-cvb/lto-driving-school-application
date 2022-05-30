using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrivingSchoolEnrollmentSystem.Models
{
    public class Util
    {
        
    }

    public class SqlParameter
    {
        private string _paramName = string.Empty;
        private object _paramVal = null;

        public String ParameterName
        {
            get { return _paramName; }
            set { _paramName = value; }
        }

        public object ParameterValue
        {
            get { return _paramVal; }
            set { _paramVal = value; }
        }
    }
}
