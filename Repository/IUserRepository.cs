using sqlinj.Models;

namespace sqlinj.Repository
{
    public interface IUserRepository
    {
        bool AuthenticateUser(AppUser appUser);
    }
}