namespace Service.DTOs.ControllerPropDTOs.AccountDTOs
{
    public class PermissionDTO
    {
        public string RoleId { get; set; }
        public IList<RoleClaimsDTO> RoleClaims { get; set; }
    }

    public class RoleClaimsDTO
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public bool Selected { get; set; }
    }
}
