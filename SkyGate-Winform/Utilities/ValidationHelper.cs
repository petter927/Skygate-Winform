using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SkyGate_ADONET.Utilities
{
    public static class ValidationHelper
    {
        public static bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool ValidatePhone(string phone)
        {
            if (string.IsNullOrEmpty(phone)) return false;
            return Regex.IsMatch(phone, @"^09\d{8}$");
        }

        public static bool ValidateEmployeeId(string empId)
        {
            if (string.IsNullOrEmpty(empId)) return false;
            return Regex.IsMatch(empId, @"^E\d{3}$");
        }

        public static bool ValidateRoleID(string roleId)
        {
            if (string.IsNullOrWhiteSpace(roleId)) return false;
            return Regex.IsMatch(roleId, @"^R\d{3}$");
        }
    }
}
