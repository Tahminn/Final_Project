namespace Service.Models
{
    public class ManageUserRolesDTO
    {
        public string UserId { get; set; }
        public IList<UserRolesDTO> UserRoles { get; set; }
    }

    public class UserRolesDTO
    {
        public string RoleName { get; set; }
        public bool Selected { get; set; }
    }
}