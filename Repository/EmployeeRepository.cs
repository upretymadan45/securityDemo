using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using sqlinj.Models;

namespace sqlinj.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string connectionString;
        public EmployeeRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public bool Create(Employee employee)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var query = $"Insert into Employees(FullName,Age) values('{employee.FullName}',{employee.Age})";

                var command = new SqlCommand(query, conn);

                var result = command.ExecuteNonQuery() > 0;

                return result;
            }
        }

        public List<Employee> GetAllEmployees(string employeeName)
        {
            var employees = new List<Employee>();

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var query = "";

                if (string.IsNullOrEmpty(employeeName))
                {
                    query = $"select * from Employees";
                }
                else
                {
                    query = $"select * from Employees where FullName like '%{employeeName}%'";
                }

                var command = new SqlCommand(query, conn);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var employee = new Employee
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        FullName = reader["FullName"].ToString(),
                        Age = Convert.ToInt32(reader["Age"])
                    };

                    employees.Add(employee);
                }
            }
            return employees;
        }
    }
}