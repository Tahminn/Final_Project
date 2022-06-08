namespace Service.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(string username, string name, string surname, List<string> roles);
    }
}
