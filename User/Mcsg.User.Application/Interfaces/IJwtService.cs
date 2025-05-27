namespace Interfaces
{
    public interface IJwtService
    {
        string GenerateAccessToken(Models.User user);
        string GenerateRefreshToken();
    }
}
