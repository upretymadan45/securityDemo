using System;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using sqlinj.Models;

namespace sqlinj.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionString;

        public UserRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool AuthenticateUser(AppUser user)
        {
            using (var conn = new SqlConnection(this.connectionString))
            {
                conn.Open();

                var sqlQuery = $"select count(Id) from AppUsers where username='{user.UserName}' and password='{user.Password}'";

                var sqlCommand = new SqlCommand(sqlQuery, conn);

                var result = Convert.ToInt32(sqlCommand.ExecuteScalar());

                return result > 0;
            }
        }
    }
}