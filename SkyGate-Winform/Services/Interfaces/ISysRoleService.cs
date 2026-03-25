using SkyGate_ADONET.DAL.Repositories;
using SkyGate_ADONET.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.Services.Interfaces
{
    public interface ISysRoleService
    {
        List<SysRole> GetAllSysRoles();
        SysRole GetSysRoleById(string roleId);        

    }
}
