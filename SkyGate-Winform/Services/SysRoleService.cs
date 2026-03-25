using SkyGate_ADONET.DAL.Repositories;
using SkyGate_ADONET.Models.Entities;
using SkyGate_ADONET.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyGate_ADONET.Services
{
    public class SysRoleService:ISysRoleService
    {
        private readonly ISysRoleRepository _sysRoleRepository;
        public SysRoleService(ISysRoleRepository sysRoleRepository)
        {
            _sysRoleRepository = sysRoleRepository;
        }
        public List<SysRole> GetAllSysRoles()
        {
            return _sysRoleRepository.GetAllSysRoles();
        }
        public SysRole GetSysRoleById(string roleId)
        {
            return _sysRoleRepository.GetSysRoleById(roleId);
        }        
    }
}
