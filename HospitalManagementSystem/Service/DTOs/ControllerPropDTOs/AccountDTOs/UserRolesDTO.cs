namespace Service.DTOs.ControllerPropDTOs.AccountDTOs
{
    public class ManageUserRolesDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public IList<UserRolesDTO> UserRoles { get; set; }
    }

    public class UserRolesDTO
    {
        public string RoleName { get; set; }
        public bool Selected { get; set; }
    }
}