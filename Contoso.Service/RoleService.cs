using System.Collections.Generic;
using System.Linq;
using Contoso.Data.Repositories;
using Contoso.Model.Models;

namespace Contoso.Service
{
    public class RoleService:IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public List<Role> GetAllRoles()
        {
            return _roleRepository.GetAll().ToList();
        }
    }

    public interface IRoleService
    {
        List<Role> GetAllRoles();
    }
}