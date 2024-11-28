using API.Entities;

namespace API.BusinessLayer
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
