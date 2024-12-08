using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiPondOrderSystemManagement.Repositories.DTOs
{
    public static class UserRoles
    {
        public static List<RolesModel> GetRoleList()
        {
            return new List<RolesModel>()
            {
                new RolesModel {RoleId = 1, RoleName = "Manager"},
                new RolesModel {RoleId = 2, RoleName = "ConstructionStaff"},
                new RolesModel {RoleId = 3, RoleName = "DesignStaff"},
                new RolesModel {RoleId = 4, RoleName = "ConsultingStaff"},
                new RolesModel {RoleId = 5, RoleName = "Customer"}
            };
        }
    }

    public class RolesModel
    {
        public string RoleName { get; set; } = null!;
        public int RoleId { get; set; }
    }
}
