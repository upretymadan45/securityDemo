using System.Collections.Generic;
using sqlinj.Models;

namespace sqlinj.Repository
{
    public interface IEmployeeRepository
    {
        bool Create(Employee employee);
        List<Employee> GetAllEmployees(string employeeName);
    }
}