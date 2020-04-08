using Microsoft.AspNetCore.Http;
using sqlinj.Models;

namespace sqlinj.Repository
{
    public interface IUserDetail
    {
        bool IsUserLoggedIn();

        string GetLoggedInUser();
    }
}