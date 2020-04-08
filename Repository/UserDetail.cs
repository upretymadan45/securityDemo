using Microsoft.AspNetCore.Http;
using sqlinj.Models;

namespace sqlinj.Repository
{
    public class UserDetail : IUserDetail
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserDetail(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string GetLoggedInUser()
        {
            return httpContextAccessor.HttpContext.Session.GetString("UserName");
        }

        public bool IsUserLoggedIn()
        {
            var isLoggedIn = httpContextAccessor.HttpContext.Session.GetString("isLoggedIn");
            return string.Equals(isLoggedIn, "true");
        }
    }
}