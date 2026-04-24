using TaskManagement.Entities;

namespace TaskManagement.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}
