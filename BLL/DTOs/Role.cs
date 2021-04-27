namespace BLL.DTOs
{
    public class Role
    {
        public Role(int roleId, string roleName, string roleDescription)
        {
            RoleId = roleId;
            RoleName = roleName;
            RoleDescription = roleDescription;
        }

        public int RoleId { get; }
        public string RoleName { get; }
        public string RoleDescription { get; }
    }
}
