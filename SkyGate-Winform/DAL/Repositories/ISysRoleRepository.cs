using SkyGate_ADONET.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.DAL.Repositories
{
    public interface ISysRoleRepository
    {

        List<SysRole> GetAllSysRoles();
        SysRole GetSysRoleById(string roleid);       
        bool CreateSysRole(SysRole sysrole);
        bool UpdateSysRole(SysRole sysrole);
        string GetIdByRoleName(string roleName);
        string GetRoleNameByRoleID(string roleid);
    }
}
