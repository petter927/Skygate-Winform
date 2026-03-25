using SkyGate_ADONET.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.Services.Utilities
{
    public static class RoleConverter
    {
        public static string ToCode(UserRole role)
        {
            switch (role)
            {
                case UserRole.Employee:
                    return "R001";
                case UserRole.Supervisor:
                    return "R002";
                case UserRole.HR:
                    return "R003";
                case UserRole.Admin:
                    return "R004";
                default:
                    return "R001";
            }
        }

        public static UserRole FromCode(string code)
        {
            if (code == "R001")
                return UserRole.Employee;
            else if (code == "R002")
                return UserRole.Supervisor;
            else if (code == "R003")
                return UserRole.HR;
            else if (code == "R004")
                return UserRole.Admin;
            else
                return UserRole.Employee;
        }

        public static string GetRoleName(string roleId)
        {
            UserRole role = FromCode(roleId);

            switch (role)
            {
                case UserRole.Employee:
                    return "員工";
                case UserRole.Supervisor:
                    return "主管";
                case UserRole.HR:
                    return "人事";
                case UserRole.Admin:
                    return "系統管理員";
                default:
                    return "未知角色";
            }
        }

        public static string GetRoleNameFromEnum(UserRole role)
        {
            switch (role)
            {
                case UserRole.Employee:
                    return "員工";
                case UserRole.Supervisor:
                    return "主管";
                case UserRole.HR:
                    return "人事";
                case UserRole.Admin:
                    return "系統管理員";
                default:
                    return "未知角色";
            }
        }
    }
}
