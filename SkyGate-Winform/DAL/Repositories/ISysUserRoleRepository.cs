using SkyGate_ADONET.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.DAL.Repositories
{
    public interface ISysUserRoleRepository
    {
        List<SysUserRole> GetAllSysUserRole();
        bool UpdateSysUserRoleByID(SysUserRole sysuserrole);
        bool CreateSysUserRole(SysUserRole sysuserrole);
        string GetRoleIDByEmpID(string empID);
    }
}
