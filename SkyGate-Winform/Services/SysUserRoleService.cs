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
    public class SysUserRoleService: ISysUserRoleService
    {
        private readonly ISysUserRoleRepository _sysUserRoleRepository;

        public SysUserRoleService(ISysUserRoleRepository sysUserRoleRepository)
        {
            _sysUserRoleRepository = sysUserRoleRepository;
        }   

        public List<SysUserRole> GetAllSysUserRole()
        {
            return _sysUserRoleRepository.GetAllSysUserRole();
        }

        public bool CreateSysUserRole(SysUserRole sysuserrole)
        {
            return _sysUserRoleRepository.CreateSysUserRole(sysuserrole);
        }

        public bool UpdateSysUserRoleByID(SysUserRole sysuserrole)
        {
            return _sysUserRoleRepository.UpdateSysUserRoleByID(sysuserrole);
        }
    }
}
